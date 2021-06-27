use camilton

GO
CREATE PROCEDURE camilton.insCli
       @nome                         VARCHAR(50), 
       @contacto                     Int        , 
       @endereco                     VARCHAR(50) 
AS 
BEGIN 
     SET NOCOUNT ON 

	 DECLARE @id INT;
	 SELECT @id=MAX(clienteID) FROM camilton.Cliente;

     INSERT INTO camilton.Cliente
          (                    
            clienteId             ,
            nome                  ,
            contacto              ,
            endereco                 
          ) 
     VALUES 
          ( 
            @id+1,
            @nome,
            @contacto,
            @endereco
          ) 

END 

GO

GO
CREATE PROC camilton.insEnc
		@quantidade                     INT,
		@envio							DATE,
		@name							VARCHAR(30),
		@prodName						VARCHAR(30)
AS 
BEGIN 
     SET NOCOUNT ON 

	 if ((select count(1) from camilton.Envio where Envio.DataEnvio=@envio) = 0)
		insert into camilton.Envio values (@envio)

	DECLARE @encomenID INT;
	SELECT @encomenID=MAX(EncomenID) FROM camilton.Encomenda;
	DECLARE @id INT;
	SELECT @id=clienteID FROM camilton.Cliente where nome like @name;
	DECLARE @prodID INT;
	SELECT TOP 1 @prodID=ProductID FROM camilton.Produto where nome like @prodName;

     INSERT INTO camilton.Encomenda
          (                    
            EncomenID				,
            Quantidade              ,
            ProntoEnv				,
            FK_Cliente				,
			FK_Envio				
          ) 
     VALUES 
          ( 
            @encomenID+1,
            @quantidade,
            0,
            @id,
			@envio
          )

	INSERT INTO camilton.Pertence
          (                    
            EncomenID				,
			ProductID				
          ) 
     VALUES 
          ( 
            @encomenID+1,
            @prodID
          )
END 
GO

GO
CREATE proc camilton.updatePronto
AS
	BEGIN
		MERGE INTO camilton.Encomenda Enc
			USING (SELECT enc.EncomenID
				FROM ((camilton.Seccao as sec JOIN camilton.Producao as prod ON sec.nota = prod.nota)
				JOIN camilton.Requer as req ON prod.nota = req.Nota)
				JOIN camilton.Encomenda as enc ON req.EncomenID = enc.EncomenID
				GROUP BY sec.nota, enc.EncomenID
				HAVING COUNT(sec.nota) = 4
				) S
			ON Enc.EncomenID = S.EncomenID AND Enc.ProntoEnv = 0
		WHEN MATCHED THEN
			UPDATE
				set ProntoEnv = 1;
	END;
go


/*drop proc camilton.updatePronto
exec camilton.updatePronto
update camilton.Encomenda set ProntoEnv = 0 where ProntoEnv = 1
select camilton.Producao.nota, ProntoEnv, DataFim from (camilton.Encomenda  JOIN camilton.Requer ON camilton.Encomenda.EncomenID=camilton.Requer.EncomenID) JOIN camilton.Producao on camilton.Requer.Nota = camilton.Producao.nota
*/



go
create proc camilton.delEnc @encomenID as INT
as
begin
    delete camilton.Requer where camilton.Requer.EncomenID = @encomenID;
	delete camilton.Pertence where camilton.Pertence.EncomenID=@encomenID;
	delete camilton.Encomenda where camilton.Encomenda.EncomenID=@encomenID;
end
go
	

GO
CREATE PROC camilton.insSolas
		@ref						INT,
		@size						REAL
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.Solas
          (                    
            referencia				,
			tamanho				
          ) 
     VALUES 
          ( 
            @ref,
            @size
          )  
END 
GO

GO
CREATE PROCEDURE camilton.createMat
       @refMat						INT, 
       @stck						INT 
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.Materiais
          (                    
            referencia       ,
            stock                 
          ) 
     VALUES 
          ( 
            @refMat,
            @stck
          ) 

END 
GO

GO
CREATE PROC camilton.insPele
		@ref						INT,
		@cor						varchar(30)
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.Pele
          (                    
            referencia				,
			cor			
          ) 
     VALUES 
          ( 
            @ref,
            @cor
          ) 
END 
GO 

GO
CREATE PROC camilton.insPalmilhas
		@ref						INT,
		@size						REAL
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.Palmilhas
          (                    
            referencia				,
			tamanho				
          ) 
     VALUES 
          ( 
            @ref,
            @size
          ) 
END 
GO

GO
CREATE PROC camilton.insAplicacoes
		@ref						INT,
		@type						VARCHAR(30)
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.Aplicacoes
          (                    
            referencia				,
			tipo				
          ) 
     VALUES 
          ( 
            @ref,
            @type
          ) 
	
END 
GO

GO
CREATE PROC camilton.insForn
		@name							varchar(30), 
		@contacto						INT, 
		@material						INT,
		@catFor							INT
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.fornecedor
          (                    
            nome					,
            contacto				,
            FK_Material				,
            FK_catFor								
          ) 
     VALUES 
          ( 
            @name,
            @contacto,
            @material,
			@catFor
          ) 

END 
GO

GO
CREATE PROC camilton.insProd
		@prodID						INT,
		@name						VARCHAR(30),
		@typeProd					INT,
		@producao					INT,
		@price						INT
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.Produto
          (                    
            ProductID			,
			nome				,
			FK_TipoProd			,
			FK_Produc			,
			preco				
          ) 
     VALUES 
          ( 
            @prodID,
			@name,
			@typeProd,
			@producao,
			@price
          ) 
END 
GO

exec camilton.insPalmilhas 1033, 37 

go
create proc camilton.insPertence
	@encomenID INT,
	@ProductID INT
	as
	begin
		if ((select count(1) from camilton.Encomenda where Encomenda.EncomenID=@encomenID) > 0)
			begin
			if((select count(1) from camilton.Produto where Produto.ProductID=@ProductID) > 0)
			begin
				insert into camilton.Pertence(
				ProductID,
				EncomenID
				)
				Values(
				@ProductID,
				@encomenID
				)
			end
		end
	end
go

go 
create proc camilton.insSeccao
    @nota int,
    @dataini date,
    @datafim date,
    @FK_TPSeccao int
as
begin
    SET NOCOUNT ON;
    insert into camilton.Seccao(
    nota,
    DataIni,
    DataFim,
    FK_TPSeccao
    )
    values(
    @nota,
    @dataini,
    @datafim,
    @FK_TPSeccao
    )
end
go

