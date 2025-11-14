from fastapi import FastAPI, Depends
from sqlalchemy.orm import Session
from typing import List
from Models.database import SessionLocal
from Models.reservation_model import Reservation
from Models.schemas import reservationSchema
from Model_IA.regression_model import train_linear_model

app = FastAPI()


# ---------------------------
# DB Dependency
# ---------------------------
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


# ---------------------------
# Get all reservations
# ---------------------------
@app.get("/reservations", response_model=List[reservationSchema])
def read_reservations(db: Session = Depends(get_db)):
    return db.query(Reservation).all()


# ---------------------------
# Train AI Model
# ---------------------------
@app.get("/train-model")
def train_model():
    model = train_linear_model()

    if model is None:
        return {"message": "No data available to train the model."}

    return {"message": "Model trained successfully!"}
