
CREATE TABLE `pastes` (
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  uid varchar(45) NOT NULL,
  title varchar(250) NOT NULL,
  language varchar(50) NOT NULL,
  code varchar(4000) DEFAULT NULL,
  creationDate datetime NOT NULL,
  expirationDate datetime,
  UNIQUE (uid)
);
