from fastapi import FastAPI
from fastapi import Depends
from sqlalchemy.orm import Session
from typing import List
from Models.database import SessionLocal
from Models.reservation_model import Reservation
from Models.schemas import reservationSchema 

app = FastAPI()



def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

@app.get("/reservations", response_model=List[reservationSchema])
def read_reservations(db: Session = Depends(get_db)):
    return db.query(Reservation).all()