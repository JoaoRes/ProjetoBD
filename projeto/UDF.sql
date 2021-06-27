

use camilton;


GO
CREATE FUNCTION camilton.getClients () RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
		RETURN;
	END;
GO
SELECT * FROM camilton.getClients();

GO
CREATE FUNCTION camilton.getClientsID (@id as INT) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where clienteID = @id
		RETURN;
	END;
GO
SELECT * FROM camilton.getClientsID(12345);

GO
CREATE FUNCTION camilton.getClientsName (@name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM camilton.getClientsName('Ricardo');

GO
CREATE FUNCTION camilton.getClientsCont (@contacto as INT) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where contacto = @contacto
		RETURN;
	END;
GO
SELECT * FROM camilton.getClientsCont(912850654);

GO
CREATE FUNCTION camilton.getClientsIdCont (@id as INT, @contacto as INT) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where contacto = @contacto AND clienteID = @id
		RETURN;
	END;
GO
SELECT * FROM camilton.getClientsIdCont(12345,912850654);

GO
CREATE FUNCTION camilton.getClientsIdName (@id as INT, @name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where clienteID = @id AND nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM camilton.getClientsIdName(12345, 'Esteves');

GO
CREATE FUNCTION camilton.getClientsContName (@contacto as INT, @name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where contacto = @contacto AND nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM camilton.getClientsContName(912850654, 'Esteves');



GO
CREATE FUNCTION camilton.getClientsIdContName (@id as INT, @contacto as INT, @name as VARCHAR(50)) RETURNS @CliTable TABLE([clienteID] INT, [nome] VARCHAR(50), [contacto] INT, [endereco] VARCHAR(50))
AS
	BEGIN
		INSERT @CliTable
			SELECT clienteID, nome, contacto, endereco
			FROM Cliente
			where @id = clienteID AND contacto = @contacto AND nome like '%'+@name+'%'
		RETURN;
	END;
GO
SELECT * FROM camilton.getClientsIdContName(12345,912850654, 'Esteves');




Go
Create Function camilton.getProntoEnvio () RETURNS @ShipmentTable TABLE([EncomenID] INT, [dataenvio] date)
as
	begin
		INSERT @ShipmentTable
			SELECT EncomenID, FK_Envio
			from Encomenda
			where ProntoEnv = 1
		RETURN;
	END;
go

SELECT * FROM camilton.getProntoEnvio()


go 
create Function camilton.getEncomenda (@encomenID as int) RETURNS @EncomendaTable TABLE([EncomenID] int, [cliente] varchar(50), [produto] varchar(30), [quantidade] int, [preco] int)
as
	begin
		insert @EncomendaTable
			Select camilton.Encomenda.EncomenID, camilton.Cliente.nome, camilton.Produto.nome, camilton.Encomenda.Quantidade, camilton.Encomenda.Quantidade*camilton.Produto.preco
			from ((camilton.Encomenda join camilton.Pertence on camilton.Encomenda.EncomenID=camilton.pertence.EncomenID) join camilton.Produto on camilton.Produto.ProductID=camilton.pertence.ProductID) join camilton.Cliente on camilton.Cliente.clienteID=camilton.Encomenda.FK_Cliente 
			where @encomenID= camilton.Encomenda.EncomenID
		RETURN;
	END
GO




go 
Create function camilton.getProdutosComCliente () RETURNS @ProdutoTable TABLE([cliente] varchar(50), [produto] varchar(30))
as 
	begin
		insert @ProdutoTable
			select camilton.Cliente.nome, camilton.Produto.nome
			from ((camilton.Encomenda join camilton.Pertence on camilton.Encomenda.EncomenID=camilton.pertence.EncomenID) join camilton.Produto on camilton.Produto.ProductID=camilton.pertence.ProductID) join camilton.Cliente on camilton.Cliente.clienteID=camilton.Encomenda.FK_Cliente
		Return;
	end
go

go 
Create function camilton.getProdutosporCliente (@cliename as varchar(30)) RETURNS @ProdutoTable TABLE([cliente] varchar(50), [produto] varchar(30), [Ref Produto] int, [tipo] varchar(30))
as 
	begin
		insert @ProdutoTable
			select camilton.Cliente.nome, camilton.Produto.nome, camilton.Produto.ProductID , camilton.TipoProd.designacao
			from ((camilton.Encomenda join camilton.Pertence on camilton.Encomenda.EncomenID=camilton.pertence.EncomenID) join camilton.Produto on camilton.Produto.ProductID=camilton.pertence.ProductID join camilton.TipoProd on camilton.Produto.FK_TipoProd=camilton.TipoProd.codigo) join camilton.Cliente on camilton.Cliente.clienteID=camilton.Encomenda.FK_Cliente
			where @cliename=camilton.Cliente.nome
		Return;
	end
go


go 
Create function camilton.getProdutosComEncomenda () RETURNS @ProdutoTable TABLE([Encomenda] varchar(50), [produto] varchar(30), [Ref Produto] int, [tipo] varchar(30))
as 
	begin
		insert @ProdutoTable
			select camilton.Encomenda.EncomenID, camilton.Produto.nome, camilton.Produto.ProductID,camilton.TipoProd.designacao
			from ((camilton.Encomenda join camilton.Pertence on camilton.Encomenda.EncomenID=camilton.pertence.EncomenID) join camilton.Produto on camilton.Produto.ProductID=camilton.pertence.ProductID join camilton.TipoProd on camilton.Produto.FK_TipoProd=camilton.TipoProd.codigo)
		Return;
	end
go


go 
Create function camilton.getProdutosporEncomenda (@EncomenID int) RETURNS @ProdutoTable TABLE([Encomenda] varchar(50), [produto] varchar(30), [Ref Produto] int, [tipo] varchar(30))
as 
	begin
		insert @ProdutoTable
			select camilton.Encomenda.EncomenID, camilton.Produto.nome, camilton.Produto.ProductID,camilton.TipoProd.designacao
			from ((camilton.Encomenda join camilton.Pertence on camilton.Encomenda.EncomenID=camilton.pertence.EncomenID) join camilton.Produto on camilton.Produto.ProductID=camilton.pertence.ProductID join camilton.TipoProd on camilton.Produto.FK_TipoProd=camilton.TipoProd.codigo)
			where @EncomenID = camilton.Encomenda.EncomenID
		Return;
	end
go


go 
Create function camilton.getSolasPorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [tamanho] int)
as
	begin
		insert @ProdutoTable
			select camilton.CategFornec.tipoMaterial, camilton.Materiais.stock, camilton.Solas.tamanho
			from  ((camilton.solas join camilton.Materiais on camilton.solas.referencia=camilton.Materiais.referencia) join camilton.fornecedor on camilton.Materiais.referencia=camilton.fornecedor.FK_Material) join camilton.CategFornec on camilton.fornecedor.FK_catFor=camilton.CategFornec.codigo
			where @Referencia=camilton.Materiais.referencia 	
		RETURN
	END
GO

go 
Create function camilton.getPelePorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [cor] int)
as
	begin
		insert @ProdutoTable
			select camilton.CategFornec.tipoMaterial, camilton.Materiais.stock, camilton.Pele.cor
			from  ((camilton.Pele join camilton.Materiais on camilton.Pele.referencia=camilton.Materiais.referencia) join camilton.fornecedor on camilton.Materiais.referencia=camilton.fornecedor.FK_Material) join camilton.CategFornec on camilton.fornecedor.FK_catFor=camilton.CategFornec.codigo
			where @Referencia=camilton.Materiais.referencia 	
		RETURN
	END
GO

go 
Create function camilton.getPalminhasPorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [tamanho] int)
as
	begin
		insert @ProdutoTable
			select camilton.CategFornec.tipoMaterial, camilton.Materiais.stock, camilton.Palmilhas.tamanho
			from  ((camilton.Palmilhas join camilton.Materiais on camilton.Palmilhas.referencia=camilton.Materiais.referencia) join camilton.fornecedor on camilton.Materiais.referencia=camilton.fornecedor.FK_Material) join camilton.CategFornec on camilton.fornecedor.FK_catFor=camilton.CategFornec.codigo
			where @Referencia=camilton.Materiais.referencia 	
		RETURN
	END
GO

go 
Create function camilton.getAplicacoesPorReferencia (@Referencia int) RETURNS @ProdutoTable TABLE ([material] varchar(50), [stock] int, [tipo] int)
as
	begin
		insert @ProdutoTable
			select camilton.CategFornec.tipoMaterial, camilton.Materiais.stock, camilton.Aplicacoes.tipo
			from  ((camilton.Aplicacoes join camilton.Materiais on camilton.Aplicacoes.referencia=camilton.Materiais.referencia) join camilton.fornecedor on camilton.Materiais.referencia=camilton.fornecedor.FK_Material) join camilton.CategFornec on camilton.fornecedor.FK_catFor=camilton.CategFornec.codigo
			where @Referencia=camilton.Materiais.referencia 	
		RETURN
	END
GO

go
create function ReferenciasPorProduto () RETURNS @ProdutoTable TABLE ([produtoID] varchar(50), [Nome Produto] varchar(30), [material] varchar(30), [referencia] int, [quantidade] int)
as
	begin
		insert @ProdutoTable
			select Produto.productID, Produto.nome, CategFornec.TipoMaterial, Materiais.Referencia, Precisa.Quantidade
			from ((Produto join precisa on Produto.ProductID=precisa.ProductID)join Materiais on  Materiais.referencia=precisa.referencia) join fornecedor on fornecedor.FK_Material=Materiais.referencia join CategFornec on Fornecedor.FK_CatFor=CategFornec.codigo
		Return
	end
go


go
create function ReferenciasPorUmProduto (@prodID as int) RETURNS @ProdutoTable TABLE ([produtoID] varchar(50), [Nome Produto] varchar(30), [material] varchar(30), [referencia] int, [quantidade] int)
as
	begin
		insert @ProdutoTable
			select camilton.Produto.productID, camilton.Produto.nome, camilton.CategFornec.TipoMaterial, camilton.Materiais.Referencia, camilton.Precisa.Quantidade
			from ((camilton.Produto join camilton.precisa on camilton.Produto.ProductID=camilton.precisa.ProductID) join camilton.Materiais on camilton.Materiais.referencia=camilton.precisa.referencia) join camilton.fornecedor on camilton.fornecedor.FK_Material=camilton.Materiais.referencia join camilton.CategFornec on camilton.Fornecedor.FK_CatFor=camilton.CategFornec.codigo
			where @prodID = camilton.Produto.productID
		Return
	end
go









