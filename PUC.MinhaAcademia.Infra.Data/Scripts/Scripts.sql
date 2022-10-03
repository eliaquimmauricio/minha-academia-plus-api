CREATE TABLE Usuarios
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Usuario VARCHAR(100) UNIQUE,
	Senha VARCHAR(100) NOT NULL,
    TipoUsuario VARCHAR(100) NOT NULL
)

INSERT INTO Usuarios (Usuario, Senha, TipoUsuario) VALUES ('User-Aluno', '123456', 'Aluno')
INSERT INTO Usuarios (Usuario, Senha, TipoUsuario) VALUES ('User-Instrutor', '123456', 'Instrutor')

CREATE TABLE DadosPessoais
(
	IdUsuarios INT NOT NULL PRIMARY KEY,
	NomeCompleto VARCHAR(255) NOT NULL,
	Apelido VARCHAR(255),
	DataNascimento DATETIME NOT NULL,
	CONSTRAINT FK_IdUsuarios FOREIGN KEY (IdUsuarios) REFERENCES Usuarios (Id) ON DELETE CASCADE
)

INSERT INTO DadosPessoais VALUES (1, 'Eliaquim Dos Santos Mauricio', 'Eliaquim', '1994-02-25')
INSERT INTO DadosPessoais VALUES (2, 'Eliaquim Dos Santos Mauricio', 'Eliaquim', '1994-02-25')

CREATE TABLE DetalhesFisicos
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	IdUsuarios INT NOT NULL,
	Peso FLOAT,
	PercentualGordura FLOAT,
	Observacao VARCHAR(255),
	DataHoraCadastro DATETIME NOT NULL DEFAULT GETDATE(),
	CONSTRAINT FK_DetalhesFisicos_IdUsuarios FOREIGN KEY (IdUsuarios) REFERENCES Usuarios (Id) ON DELETE CASCADE
)


INSERT INTO DetalhesFisicos (IdUsuarios, Peso, PercentualGordura, Observacao) VALUES (1, 85.5, 5.0, 'Blábláblá')
INSERT INTO DetalhesFisicos (IdUsuarios, Peso, PercentualGordura, Observacao) VALUES (1, 90.5, 5.0, 'Blábláblá')
INSERT INTO DetalhesFisicos (IdUsuarios, Peso, PercentualGordura, Observacao) VALUES (1, 90.5, 5.0, 'Blábláblá')

INSERT INTO DetalhesFisicos (IdUsuarios, Peso, PercentualGordura, Observacao) VALUES (2, 85.5, 5.0, 'Blábláblá')
INSERT INTO DetalhesFisicos (IdUsuarios, Peso, PercentualGordura, Observacao) VALUES (2, 90.5, 5.0, 'Blábláblá')
INSERT INTO DetalhesFisicos (IdUsuarios, Peso, PercentualGordura, Observacao) VALUES (2, 90.5, 5.0, 'Blábláblá')


CREATE TABLE Exercicios
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	IdUsuarios INT NOT NULL,
	DiaDaSemana TINYINT NOT NULL,
	Ordem TINYINT NOT NULL,
	NomeExercicio VARCHAR(255) NOT NULL,
	QuantidadeDeSeries INT NOT NULL,
	QuantidadeDeRepeticoes INT NOT NULL,
	Carga FLOAT,
	ObservacaoAluno VARCHAR(255),
	ObservacaoInstrutor VARCHAR(255),
	CONSTRAINT FK_Exercicios_IdUsuarios FOREIGN KEY (IdUsuarios) REFERENCES Usuarios (Id) ON DELETE CASCADE
)

INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 2, 1, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 2, 2, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 2, 3, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 2, 4, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 2, 5, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 4, 1, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 4, 2, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 4, 3, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 4, 4, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 6, 1, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 6, 2, 'Rosca Biceps', 3, 10)
INSERT INTO Exercicios (IdUsuarios, DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes) VALUES (1, 6, 3, 'Rosca Biceps', 3, 10)
