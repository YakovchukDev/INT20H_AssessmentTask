CREATE DATABASE INT20H;
CREATE TABLE Developers(
    ID SERIAL PRIMARY KEY,
    Name TEXT,
    Project_id INTEGER
);
CREATE TABLE Projects(
    ID SERIAL PRIMARY KEY,
    Name TEXT UNIQUE
);
SELECT Developers.id, Developers.name, Projects.name 
FROM Developers 
JOIN Projects ON Developers.project_id=Projects.id;