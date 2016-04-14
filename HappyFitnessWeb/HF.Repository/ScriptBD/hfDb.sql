CREATE DATABASE HappyFitnessApp

GO

USE HappyFitnessApp

GO

CREATE SCHEMA [hf]
AUTHORIZATION dbo

GO

CREATE TABLE [hf].[Academia]
(
	[AcademiaCodigo] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nome] VARCHAR(150) NOT NULL
)

GO

CREATE TABLE [hf].[Pessoa]
(
	[PessoaCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] VARCHAR (25) NOT NULL,
	[Tipo] int NOT NULL
)

GO

CREATE TABLE [hf].[PessoaAcademia]
(
	[PessoaAcademiaCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[PessoaCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Pessoa]([PessoaCodigo]),
	[AcademiaCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Academia]([AcademiaCodigo]),
	[Situacao] BIT NOT NULL
)

GO

CREATE TABLE [hf].[Treino]
(
	[TreinoCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[AlunoCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Pessoa]([PessoaCodigo]),
	[InstrutorCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Pessoa]([PessoaCodigo]),
	[Tipo] INT NOT NULL,
	[DataHoraInicio] DATETIME NOT NULL,
	[DataHoraFim] DATETIME  NOT NULL
)

GO

CREATE TABLE [hf].[TreinoDiario]
(
	[TreinoDiarioCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TreinoCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Treino]([TreinoCodigo]),
	[Tipo] INT
)

GO

CREATE TABLE [hf].[Serie]
(
	[SerieCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Repeticoes] INT,
	[Peso] DECIMAL(3,2),
	[TempoSegundos] INT,
	[ExercicioCodigo] INT NOT NULL
)


GO

CREATE TABLE [hf].[Atividade]
(
	[AtividadeCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TreinoDiarioCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[TreinoDiario]([TreinoDiarioCodigo]),
	[SerieCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Serie]([SerieCodigo]),
	[Feedback] INT
)

GO

CREATE TABLE [hf].[Exercicio]
(
	[ExercicioCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] VARCHAR(150) NOT NULL,
	[Descricao] VARCHAR(250)
)

GO

CREATE TABLE [hf].[Musculo]
(
	[MusculoCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] VARCHAR(150) NOT NULL
)

GO

CREATE TABLE [hf].[MusculoExercicio]
(
	MusculoExercicioCodigo INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	MusculoCodigo INT NOT NULL FOREIGN KEY REFERENCES [hf].[Musculo]([MusculoCodigo]),
	ExercicioCodigo INT NOT NULL FOREIGN KEY REFERENCES [hf].[Exercicio]([ExercicioCodigo])
)

GO

CREATE TABLE [hf].[Aparelho]
(
	[AparelhoCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] VARCHAR(150) NOT NULL
)

GO

CREATE TABLE [hf].[AparelhoExercicio]
(
	[AparelhoExercicioCodigo] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ExercicioCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Exercicio]([ExercicioCodigo]),
	[AparelhoCodigo] INT NOT NULL FOREIGN KEY REFERENCES [hf].[Aparelho]([AparelhoCodigo])
)

GO