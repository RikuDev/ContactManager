SET IDENTITY_INSERT CustomerInfoes ON

INSERT INTO  [dbo].[CustomerInfoes] (ID, Name, Latitude, Longitude)
    VALUES ('1', 'Patrick', '26.1231', '28.2314'),
		   ('2', 'Jon', '26.1231', '28.2314'),
	       ('3', 'Steve', '26.1231', '28.2314'),
	       ('4', 'Carl', '26.1231', '28.2314'),
	       ('5', 'Peter', '26.1231', '28.2314'); 

SET IDENTITY_INSERT CustomerInfoes OFF

SET IDENTITY_INSERT ContactInfoes ON
 
INSERT INTO  [dbo].[ContactInfoes] (ID, Name, Email, ContactNumber, CustomerID)
    VALUES ('1', 'Patrick', 'bla@yahoo.com', '0123814768', '1'),
		   ('2', 'Jon', 'bla@yahoo.com', '0123814768', '2'),
		   ('3', 'Steve', 'bla@yahoo.com', '0123814768', '3'),
		   ('4', 'Carl', 'bla@yahoo.com', '0123814768', '4'),
		   ('5', 'Peter', 'bla@yahoo.com', '0123814768', '5');

SET IDENTITY_INSERT ContactInfoes OFF
