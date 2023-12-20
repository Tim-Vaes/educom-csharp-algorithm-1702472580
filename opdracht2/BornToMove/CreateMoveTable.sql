USE born2move;

CREATE TABLE move
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) UNIQUE,
    Description NVARCHAR(MAX),
    SweatRate INT
);
