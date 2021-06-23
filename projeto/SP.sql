use camilton

GO
CREATE PROCEDURE camilton.insCli
       @clienteId                    INT        , 
       @nome                         VARCHAR(50), 
       @contacto                     Int        , 
       @endereco                     VARCHAR(50) 
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO camilton.Cliente
          (                    
            clienteId             ,
            nome                  ,
            contacto              ,
            endereco                 
          ) 
     VALUES 
          ( 
            @clienteId,
            @nome,
            @contacto,
            @endereco
          ) 

END 

GO


GO
CREATE PROC camilton.insEnc
		@encomenID                      INT, 
		@quantidade                     INT, 
		@clienteID						INT,
		@envio							DATE
AS 
BEGIN 
     SET NOCOUNT ON 

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
            @encomenID,
            @quantidade,
            0,
            @clienteID,
			@envio
          ) 

END 
GO

GO
CREATE proc camilton.updatePronto
AS
	BEGIN
		MERGE INTO camilton.Encomenda Enc
			USING (SELECT enc.EncomenID
				FROM ((camilton.Seccao as sec JOIN camilton.Producao as prod ON sec.nota = prod.nota) JOIN camilton.Requer as req ON prod.nota = req.Nota) JOIN camilton.Encomenda as enc ON req.EncomenID = enc.EncomenID
				GROUP BY sec.nota, enc.EncomenID
				HAVING COUNT(sec.nota) = 4
				) S
			ON Enc.EncomenID = S.EncomenID AND Enc.ProntoEnv = 0
		WHEN MATCHED THEN
			UPDATE
				set ProntoEnv = 1;
	END;
go