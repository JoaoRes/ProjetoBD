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




Go
Create Function dbo.getProntoEnvio () RETURNS @ShipmentTable TABLE([EncomenID] INT, [dataenvio] date)
as
	begin
		INSERT @ShipmentTable
			SELECT EncomenID, FK_Envio
			from Encomenda
			where ProntoEnv = 1
		RETURN;
	END;
go

SELECT * FROM dbo.getProntoEnvio()




go 
create Function dbo.getEncomenda (@encomenID as int) RETURNS @EncomendaTable TABLE([EncomenID] int, [cliente] varchar(50), [produto] varchar(30), [quantidade] int, [preco] int)
as
	begin
		insert @EncomendaTable
			Select Encomenda.EncomenID, Cliente.nome, Produto.nome, encomenda.Quantidade, Encomenda.Quantidade*Produto.preco
			from ((Encomenda join Pertence on Encomenda.EncomenID=pertence.EncomenID) join Produto on Produto.ProductID=pertence.ProductID) join Cliente on Cliente.clienteID=Encomenda.FK_Cliente 
			where @encomenID= Encomenda.EncomenID
		RETURN;
	END
GO




go 
Create function dbo.getProdutosComCliente () RETURNS @ProdutoTable TABLE([cliente] varchar(50), [produto] varchar(30))
as 
	begin
		insert @ProdutoTable
			select Cliente.nome, Produto.nome
			from ((Encomenda join Pertence on Encomenda.EncomenID=pertence.EncomenID) join Produto on Produto.ProductID=pertence.ProductID) join Cliente on Cliente.clienteID=Encomenda.FK_Cliente
		Return;
	end
go

go 
Create function dbo.getProdutosporCliente (@cliename as varchar(30)) RETURNS @ProdutoTable TABLE([cliente] varchar(50), [produto] varchar(30), [Ref Produto] int, [tipo] varchar(30))
as 
	begin
		insert @ProdutoTable
			select Cliente.nome, Produto.nome, Produto.ProductID , TipoProd.designacao
			from ((Encomenda join Pertence on Encomenda.EncomenID=pertence.EncomenID) join Produto on Produto.ProductID=pertence.ProductID join TipoProd on Produto.FK_TipoProd=TipoProd.codigo) join Cliente on Cliente.clienteID=Encomenda.FK_Cliente
			where @cliename=Cliente.nome
		Return;
	end
go


go 
Create function dbo.getProdutosComEncomenda () RETURNS @ProdutoTable TABLE([Encomenda] varchar(50), [produto] varchar(30), [Ref Produto] int, [tipo] varchar(30))
as 
	begin
		insert @ProdutoTable
			select Encomenda.EncomenID, Produto.nome, Produto.ProductID,TipoProd.designacao
			from ((Encomenda join Pertence on Encomenda.EncomenID=pertence.EncomenID) join Produto on Produto.ProductID=pertence.ProductID join TipoProd on Produto.FK_TipoProd=TipoProd.codigo)
		Return;
	end
go


go 
Create function dbo.getProdutosporEncomenda (@EncomenID int) RETURNS @ProdutoTable TABLE([Encomenda] varchar(50), [produto] varchar(30), [Ref Produto] int, [tipo] varchar(30))
as 
	begin
		insert @ProdutoTable
			select Encomenda.EncomenID, Produto.nome, Produto.ProductID,TipoProd.designacao
			from ((Encomenda join Pertence on Encomenda.EncomenID=pertence.EncomenID) join Produto on Produto.ProductID=pertence.ProductID join TipoProd on Produto.FK_TipoProd=TipoProd.codigo)
			where @EncomenID = Encomenda.EncomenID
		Return;
	end
go
*/

go 
Create function dbo.getSolasPorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [tamanho] int)
as
	begin
		insert @ProdutoTable
			select CategFornec.tipoMaterial, Materiais.stock, Solas.tamanho
			from  ((solas join Materiais on solas.referencia=Materiais.referencia) join fornecedor on Materiais.referencia=fornecedor.FK_Material) join CategFornec on fornecedor.FK_catFor=CategFornec.codigo
			where @Referencia=Materiais.referencia 	
		RETURN
	END
GO

go 
Create function dbo.getPelePorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [cor] int)
as
	begin
		insert @ProdutoTable
			select CategFornec.tipoMaterial, Materiais.stock, Pele.cor
			from  ((Pele join Materiais on Pele.referencia=Materiais.referencia) join fornecedor on Materiais.referencia=fornecedor.FK_Material) join CategFornec on fornecedor.FK_catFor=CategFornec.codigo
			where @Referencia=Materiais.referencia 	
		RETURN
	END
GO

go 
Create function dbo.getPalminhasPorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [tamanho] int)
as
	begin
		insert @ProdutoTable
			select CategFornec.tipoMaterial, Materiais.stock, Palmilhas.tamanho
			from  ((Palmilhas join Materiais on Palmilhas.referencia=Materiais.referencia) join fornecedor on Materiais.referencia=fornecedor.FK_Material) join CategFornec on fornecedor.FK_catFor=CategFornec.codigo
			where @Referencia=Materiais.referencia 	
		RETURN
	END
GO

go 
Create function dbo.getAplicacoesPorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [tipo] int)
as
	begin
		insert @ProdutoTable
			select CategFornec.tipoMaterial, Materiais.stock, Aplicacoes.tipo
			from  ((Aplicacoes join Materiais on Aplicacoes.referencia=Materiais.referencia) join fornecedor on Materiais.referencia=fornecedor.FK_Material) join CategFornec on fornecedor.FK_catFor=CategFornec.codigo
			where @Referencia=Materiais.referencia 	
		RETURN
	END
GO









