from sqlalchemy import Column, Integer, String, ForeignKey, Date, Time
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

class Reservation(Base):
    __tablename__ = "Reservations"

    Reservation_id = Column(Integer, primary_key=True, index=True)
    ClientId = Column(Integer, ForeignKey("Client.ClientId"), nullable=False)
    StadiumId = Column(Integer, ForeignKey("Stadium.Stadium_id"), nullable=False)
    ReservationDate = Column(Date, nullable=False)

    StartTime = Column(Time, nullable=False)    # <-- FIXED (was String)
    Duration = Column(Time, nullable=False)     # <-- FIXED (was Interval)

    Status = Column(String, nullable=False, default="Pending")
