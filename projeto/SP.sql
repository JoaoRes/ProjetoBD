use camilton

GO
CREATE PROCEDURE dbo.insCli
       @clienteId                    INT        , 
       @nome                         VARCHAR(50), 
       @contacto                     Int        , 
       @endereco                     VARCHAR(50) 
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO Cliente
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

Go
Create PROCEDURE dbo.UpdateProntoEnvio
as
begin	
	update Encomenda
	set ProntoEnv = 1
	where COUNT() 
