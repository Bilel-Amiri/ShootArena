from sqlalchemy import create_engine, MetaData
from sqlalchemy.orm import sessionmaker

DATABASE_URL = (
    "mssql+pyodbc://localhost:1433/Shoot"
    "?driver=ODBC+Driver+18+for+SQL+Server"
    "&trusted_connection=yes"
    "&TrustServerCertificate=yes"
)

engine = create_engine(DATABASE_URL, echo=True)

SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

metadata = MetaData()
