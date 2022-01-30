delimiter //

CREATE PROCEDURE CreatePaste(_uid VARCHAR(50), title VARCHAR(250), language VARCHAR(50), code VARCHAR(4000), expirationDate DATETIME)
BEGIN
  INSERT INTO pastes(uid, title, language, code, creationDate, expirationDate)
  VALUES(_uid, title, language, code, NOW(), expirationDate);

  SELECT id, uid, title, language, code, creationDate, expirationDate FROM pastes WHERE uid = _uid;
END//

delimiter ;



delimiter //

CREATE PROCEDURE GetPasteById(_uid VARCHAR(50))
BEGIN
  SELECT id, uid, title, language, code, creationDate, expirationDate FROM pastes WHERE uid = _uid;
END//

delimiter ;



delimiter //

CREATE PROCEDURE GetRecentPastes()
BEGIN
  SELECT id, uid, title, language, code, creationDate, expirationDate FROM pastes ORDER BY creationDate DESC LIMIT 20;
END//

delimiter ;

