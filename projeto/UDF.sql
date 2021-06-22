use camilton;

/*
GO
CREATE FUNCTION dbo.getClients () RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
		RETURN;
	END;
GO
SELECT * FROM dbo.getClients();

GO
CREATE FUNCTION dbo.getClientsID (@id as INT) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where clienteID = @id
		RETURN;
	END;
GO
SELECT * FROM dbo.getClientsID(12345);

GO
CREATE FUNCTION dbo.getClientsName (@name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM dbo.getClientsName('Ricardo');

GO
CREATE FUNCTION dbo.getClientsCont (@contacto as INT) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where contacto = @contacto
		RETURN;
	END;
GO
SELECT * FROM dbo.getClientsCont(912850654);

GO
CREATE FUNCTION dbo.getClientsIdCont (@id as INT, @contacto as INT) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where contacto = @contacto AND clienteID = @id
		RETURN;
	END;
GO
SELECT * FROM dbo.getClientsIdCont(12345,912850654);

GO
CREATE FUNCTION dbo.getClientsIdName (@id as INT, @name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where clienteID = @id AND nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM dbo.getClientsIdName(12345, 'Esteves');

GO
CREATE FUNCTION dbo.getClientsContName (@contacto as INT, @name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where contacto = @contacto AND nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM dbo.getClientsContName(912850654, 'Esteves');



GO
CREATE FUNCTION dbo.getClientsIdContName (@id as INT, @contacto as INT, @name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where @id = clienteID AND contacto = @contacto AND nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM dbo.getClientsIdContName(12345,912850654, 'Esteves');

*/