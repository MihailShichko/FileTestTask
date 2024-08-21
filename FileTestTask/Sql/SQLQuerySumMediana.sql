USE [FileTestTask]
GO

SELECT Top 1
	PERCENTILE_DISC(0.5) WITHIN GROUP (ORDER BY FractionalNum) OVER () AS MedianDecimal
  FROM [dbo].[Records]
  Union Select SUM(CAST(OddNum AS BIGINT)) As OddNumSum
  FROM [dbo].[Records]
GO


