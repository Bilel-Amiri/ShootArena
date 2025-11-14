import pandas as pd
from sklearn.linear_model import LinearRegression
from sqlalchemy import cast, String
from Models.database import SessionLocal
from Models.reservation_model import Reservation


# ---------------------------
# Helper: Convert time to minutes
# ---------------------------
def time_to_minutes_safe(t) -> int:
    if not t:
        return 0
    
    # If the value is already a string like "14:30:00"
    if isinstance(t, str):
        try:
            t = pd.to_datetime(t).time()
        except:
            return 0

    return t.hour * 60 + t.minute


# ---------------------------
# Load reservation data from DB
# ---------------------------
def get_reservations_data():
    db = SessionLocal()

    reservations = db.query(
        Reservation.Reservation_id,
        Reservation.ClientId,
        Reservation.StadiumId,
        Reservation.ReservationDate,
        cast(Reservation.StartTime, String).label("StartTime"),
        Reservation.Duration,
        Reservation.Status
    ).all()

    db.close()

    if not reservations:
        return pd.DataFrame()

    # Build rows into list of dicts
    data = []
    for r in reservations:
        # Convert Duration safely
        try:
            duration_minutes = r.Duration.hour * 60 + r.Duration.minute
        except:
            duration_minutes = 90   # default fallback

        data.append({
            "Reservation_id": r.Reservation_id,
            "ClientId": r.ClientId,
            "StadiumId": r.StadiumId,
            "ReservationDate": str(r.ReservationDate),
            "StartTime": time_to_minutes_safe(r.StartTime),
            "Duration": duration_minutes,
            "Status": 1 if r.Status == "Confirmed" else 0
        })

    return pd.DataFrame(data)


# ---------------------------
# Train linear regression model
# ---------------------------
def train_linear_model():
    df = get_reservations_data()

    if df.empty:
        return None

    # Basic example: predict duration
    X = df[["StadiumId", "ClientId"]]
    y = df["Duration"]

    model = LinearRegression()
    model.fit(X, y)

    return model
