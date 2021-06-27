create view camilton.getEncomendas
as
	select EncomenID, Quantidade from camilton.Encomenda E;

create view camilton.getClientes
as
	select nome from camilton.Cliente c;


create view camilton.getFornecedor
as
	select nome, contacto from camilton.Fornecedor f;

create view camilton.getProduto
as
	select ProductID, nome from camilton.Produto p;

