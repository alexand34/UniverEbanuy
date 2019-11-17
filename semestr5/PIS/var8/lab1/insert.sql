insert into Countries(Name)
values ('Ukraine'), ('USA'), ('Israel'), ('Germany')
GO

insert into Cities(Name, CountryId)
values ('Kiyv', 1), ('Lviv', 1), ('Kharkiv', 1),
('Chikago', 2), ('New York', 2), ('San Francisco', 2),
('Tel Aviv', 3), ('Acre', 3), ('Haifa', 3),
('Berlin', 3), ('Wesse', 3), ('Frankurt', 3)
GO


insert Cinemas (Name, CityId)
values ('Multiplex', 1), ('Zhovten', 1),
('Multiplex', 2), ('Forum', 2),
('AMC', 4), ('Nitehawk', 5), ('Regal', 6), 
('Film Forum', 7),  ('Ziegfeld', 8), ('Ziegfeld', 9),
('Kurwa match', 10),
('Landmark', 11),
('Big Bang', 12)
GO

delete from  Cinemas