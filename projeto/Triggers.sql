go 
create trigger PrecoMinimo on camilton.Produto
After insert , update
as
	begin
		SET NOCOUNT ON;
		DECLARE @preco as real
		Select @preco = inserted.preco from inserted;
		if @preco < 10
			BEGIN	
				RAISERROR ('Preco do produto demasiado baixo',16,1);
				ROLLBACK TRAN;
			END
		else  
			if @preco > 85
				begin
					RAISERROR('Preco demasiado elevado',16,1);
					ROLLBACK TRAN;
				end
			else
				Print 'VALOR DE PRODUTO APROVADO'
	end
go

go
create trigger TipoDeSeccao on camilton.Seccao
INSTEAD OF INSERT, UPDATE
as
	begin 
		SET NOCOUNT ON;
		DECLARE @tipo as int
		select @tipo = inserted.FK_TPSeccao from inserted;
		if @tipo > 4 or @tipo < 0 
			RAISERROR('TIPO DE SECCAO INVALIDA',16,1);
		else
			begin
				insert into camilton.seccao select * from inserted;
			end
	end
go

go
create trigger MaterialFornecido on camilton.Fornecedor
after insert, update 
as 
	begin
		SET NOCOUNT ON;
		DECLARE @ReferenciaFornecedor as int
		select @ReferenciaFornecedor = inserted.FK_Material from inserted;
		if @ReferenciaFornecedor = (select Materiais.referencia from camilton.Materiais)
			PRINT ('Existe mais de um fornecedor com o mesmo produto');
		else
			begin
			insert into camilton.Materiais values (@ReferenciaFornecedor,'' );
			end
	end
go

go
drop trigger UpdateStockSolas
go


go 
create trigger UpdateStockSolas on camilton.Solas
instead of insert , update
as 
	begin
		SET NOCOUNT ON;
		DECLARE @ref as int
		select @ref = inserted.Referencia from inserted;
		if (select count(1) from  camilton.Materiais where Materiais.referencia=@ref) > 0
			begin
				update camilton.Materiais
				set Materiais.Stock = Stock+1
				where @ref = Materiais.referencia
			end
		else
			begin
			insert into camilton.Solas select * from inserted;
			end
	end
go


go 
create trigger UpdateStockPele on camilton.Pele
instead of insert , update
as 
	begin
		SET NOCOUNT ON;
		DECLARE @ref as int
		select @ref = inserted.Referencia from inserted;
		if (select count(1) from  camilton.Materiais where Materiais.referencia=@ref) > 0
			begin
				update camilton.Materiais
				set Materiais.Stock = Stock+1
				where @ref = Materiais.referencia
			end
		else
			begin
			insert into camilton.Pele select * from inserted;
			end
	end
go


go 
create trigger camilton.UpdateStockAplicacoes on camilton.Aplicacoes
instead of insert , update
as 
	begin
		SET NOCOUNT ON;
		DECLARE @ref as int
		select @ref = inserted.Referencia from inserted;
		if (select count(1) from  camilton.Materiais where Materiais.referencia=@ref) > 0
			begin
				update camilton.Materiais
				set Materiais.Stock = Stock+1
				where @ref = Materiais.referencia
			end
		else
			begin
			insert into camilton.Materiais values (@ref, '');
			insert into camilton.Aplicacoes select * from inserted;
			end
	end
go


go 
create trigger camilton.UpdateStockPalmilhas on camilton.Palmilhas
instead of insert , update
as 
	begin
		SET NOCOUNT ON;
		DECLARE @ref as int
		select @ref = inserted.Referencia from inserted;
		if (select count(1) from  camilton.Materiais where Materiais.referencia=@ref) > 0
			begin
				update camilton.Materiais
				set Materiais.Stock = Stock+1
				where @ref = Materiais.referencia
			end
		else
			begin
			insert into camilton.Materiais values (@ref, '');
			insert into camilton.Palmilhas select * from inserted;
			end
	end
go



go 
create trigger camilton.UpdateAdicionarEncomenda on camilton.Encomenda
after insert, update
as 
	begin
		SET NOCOUNT ON;
		DECLARE @encomenID as int
		Declare @nota as int
		select @nota= (SELECT TOP 1 nota FROM camilton.Requer ORDER BY EncomenID DESC) + 100
		select @encomenID = inserted.EncomenID from inserted;
		insert into camilton.Producao values (@nota,'','')
		insert into camilton.Requer values (@nota,@encomenID)
	end
go


go
CREATE TRIGGER camilton.updateProdDateFim on camilton.Encomenda
after insert, Update
as
	Begin
	SET NOCOUNT ON;
	DECLARE @id as int
	select @id = inserted.EncomenID from inserted;
	UPDATE camilton.Producao SET DataFim = GETDATE() where nota = (select nota from camilton.Requer where camilton.Requer.EncomenID = @id)
	end
go

go
CREATE TRIGGER camilton.updateProdDate on camilton.Encomenda
for Update
as
	Begin
	SET NOCOUNT ON;
	DECLARE @id as int
	select @id = inserted.EncomenID from inserted;
	UPDATE camilton.Producao SET DataFim = GETDATE() where nota = (select nota from camilton.Requer where camilton.Requer.EncomenID = @id)
end
go


go
CREATE TRIGGER camilton.updateProdDateIni on camilton.Seccao
after insert , update
as
	Begin
	DECLARE @dateI as Date
	select @dateI = inserted.DataIni from inserted;
	MERGE INTO camilton.Producao P
		USING (SELECT sec.nota
		FROM ((camilton.Seccao as sec JOIN camilton.Producao as prod ON sec.nota = prod.nota)
		JOIN camilton.Requer as req ON prod.nota = req.Nota)
		JOIN camilton.Encomenda as enc ON req.EncomenID = enc.EncomenID
		GROUP BY sec.nota
		HAVING COUNT(sec.nota) = 1
		) S
		ON P.nota = S.nota
	WHEN MATCHED THEN
		UPDATE
		set DataIni = @dateI;
	end
go
	


