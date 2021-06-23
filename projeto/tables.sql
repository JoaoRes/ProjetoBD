CREATE SCHEMA camilton;

Create Table camilton.Materiais (
	referencia int not null,
	stock int not null
	primary key (referencia)
)

Create table camilton.CategFornec (
	codigo	int not null,
	tipoMaterial varchar(20) not null,
	Primary key(codigo)
)


Create Table camilton.fornecedor (
	nome varchar(30)	not null,
	contacto int,
	FK_Material int references camilton.Materiais(referencia),
	FK_catFor int references camilton.CategFornec(codigo),
	Primary key (nome)	
)

Create Table camilton.Solas (
	referencia int  references camilton.Materiais(referencia) not null,
	tamanho real not null,
	Primary key(referencia)
)

Create Table camilton.Pele (
	referencia int  references camilton.Materiais(referencia) not null,
	cor varchar(30) not null,
	Primary key(referencia)
)

Create Table camilton.Palmilhas (
	referencia int  references camilton.Materiais(referencia) not null,
	tamanho real not null,
	Primary key(referencia)
)

Create Table camilton.Aplicacoes (
	referencia int  references camilton.Materiais(referencia) not null,
	tipo varchar(30) not null,
	Primary key(referencia)
)

Create Table camilton.Producao (
	nota int not null,
	DataIni date not null,
	DataFim date
	Primary key(nota)
)

Create table camilton.TipoProd (
	codigo int not null,
	designacao varchar(30) not null,
	Primary key (codigo)
)

Create Table camilton.Produto (
	ProductID int not null,
	nome varchar(30), 
	FK_TipoProd int references camilton.TipoProd(codigo) not null,
	FK_Produc int references camilton.Producao(nota),
	preco int not null
	primary key (ProductID)
)

create table camilton.Precisa (
	ProductID int references camilton.Produto(ProductID) not null,
	Referencia int references camilton.Materiais(Referencia)not null,
	Quantidade int not null,
	Primary key(ProductID, Referencia)
)

Create table camilton.TipoSeccao (
	codigo int not null,
	Designacao varchar(30) not null
	Primary key(codigo)
)

create table camilton.Seccao (
	nota int references camilton.Producao(nota) not null,
	DataIni date not null,
	DataFim date,
	TimeTampp date,
	FK_TPSeccao int references camilton.TipoSeccao(codigo) not null,
	Primary Key (nota)
)

create table camilton.Funcionario (
	NumFunc int not null,
	nome varchar(50) not null,
	FK_Produc int references camilton.Seccao(nota),
	Primary Key (NumFunc)
)

create table camilton.Cliente (
	clienteID int not null,
	nome varchar(50) not null,
	contacto int,
	endereco varchar(50),
	Primary key(clienteID) 
)

create table camilton.envio (
	DataEnvio date not null
	Primary Key(DataEnvio)
)

create table camilton.Encomenda (
	EncomenID int not null,
	Quantidade int not null,
	ProntoEnv binary,
	FK_Cliente int references camilton.Cliente(ClienteID),
	FK_Envio date references camilton.Envio(DataEnvio),
	Primary Key (EncomenID)
)

create table camilton.Pertence (
	ProductID int references camilton.Produto(ProductID) not null,
	EncomenID int references camilton.Encomenda(EncomenID) not null,
	Primary key (ProductID, EncomenID)
)

create table camilton.Requer (
	Nota int references camilton.Producao(nota) not null,
	EncomenID int references camilton.Encomenda(EncomenID) not null,
	Primary key (Nota, EncomenID)
)

create table camilton.TipoPag (
	codigo int not null,
	condicao varchar(30) not null,
	Primary Key (codigo)
)


create table camilton.Necessita (
	EncomenID int references camilton.Encomenda(EncomenID) not null,
	codigo int references camilton.TipoPag(codigo) not null,
	Primary key (EncomenID, codigo)
)

