from pydantic import BaseModel
from datetime import date , time , timedelta


class reservationSchema(BaseModel):
    

     Reservation_id: int
     ClientId: int
     StadiumId: int
     ReservationDate: date
     StartTime: time
     Duration: timedelta
     Status: str
 
 
     model_config = {
        "from_attributes": True
    }
     
     