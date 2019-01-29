CREATE DATABASE HollywoodAssessmentDb
GO

USE HollywoodAssessmentDb

CREATE TABLE Tournament
(
	TournamentID BIGINT PRIMARY KEY IDENTITY (1000000,1),
	TournamentName VARCHAR (200)
)
GO

CREATE TABLE EventDetailStatus
(
	EventDetailStatusID SMALLINT PRIMARY KEY IDENTITY (1,1),
	EventDetailStatusName VARCHAR (50)
)
GO

CREATE TABLE [Event]
(
	EventID BIGINT PRIMARY KEY IDENTITY(2000000,1),
	TournamentID BIGINT REFERENCES Tournament(TournamentID),
	EventName VARCHAR(100),
	EventNumber SMALLINT,
	EventDateTime DATETIME,
	EventEndDateTime DATETIME,
	AutoClose BIT
)
GO

CREATE TABLE EventDetail
(
	EventDetailID BIGINT PRIMARY KEY IDENTITY(5000000,1),
	EventID BIGINT REFERENCES [Event](EventID),
	EventDetailStatusID SMALLINT REFERENCES EventDetailStatus(EventDetailStatusID),
	EventDetailName VARCHAR (50),
	EventDetailNumber SMALLINT,
	EventDetailOdd DECIMAL(18, 7),
	FinishingPosition SMALLINT,
	FirstTimer BIT
)
GO

--USE master
--DROP DATABASE HollywoodAssessmentDb

INSERT INTO EventDetailStatus
VALUES ('Active'), ('Scratched'), ('Closed')