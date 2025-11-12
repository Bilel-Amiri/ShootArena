from sqlalchemy import Column, Integer, String, ForeignKey, Date, Time, Interval
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

class Reservation(Base):
    __tablename__ = "Reservation"

    Reservation_id = Column(Integer, primary_key=True, index=True)
    ClientId = Column(Integer, ForeignKey("Client.ClientId"), nullable=False)
    StadiumId = Column(Integer, ForeignKey("Stadium.Stadium_id"), nullable=False)
    ReservationDate = Column(Date, nullable=False)       # maps from DateOnly
    StartTime = Column(Time, nullable=False)             # maps from TimeOnly
    Duration = Column(Interval, default="01:30:00")      # TimeSpan 90 minutes
    Status = Column(String, nullable=False, default="Pending")
