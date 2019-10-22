


ALTER PROCEDURE spShowCallDetailRecords
@IncludeMale BIT = NULL,
@IncludeFemale BIT = NULL,
@IncludeUnknowGender BIT = NULL,

@Include_18_to_25  BIT = NULL,
@Include_26_to_35  BIT = NULL,
@Include_36_to_45  BIT = NULL,
@Include_46_to_65  BIT = NULL,
@Include_66_to_100 BIT = NULL,

@StartDate DATETIME2 = NULL

AS
BEGIN
SET NOCOUNT ON;  -- reduces traffic back to the application. 

DECLARE @sql NVARCHAR(max)
	SET @sql = 'SELECT t.cellLong, t.cellLat, count(*) as count FROM dbo.Customer AS c
				INNER JOIN dbo.Traffic as t ON c.Number = t.aNumber
				WHERE 1=1'

	-- Gender filters
	IF (@IncludeMale = 1 OR @IncludeFemale =1 OR @IncludeUnknowGender = 1)
	BEGIN
		SELECT @sql += 'AND ('

		IF (@IncludeMale = 1)
			SELECT @sql += 'c.Gender = ''M''' 
		IF (@IncludeFemale = 1)
		BEGIN
			IF (@IncludeMale = 1)
				SELECT @sql += 'OR c.Gender = ''F'''
			ELSE
				SELECT @sql += 'c.Gender = ''F'''
		END		
		IF (@IncludeUnknowGender = 1)
		BEGIN
			IF (@IncludeMale = 1 OR @IncludeFemale = 1)
				SELECT @sql += 'OR c.Gender = ''?'''
			ELSE
				SELECT @sql += 'c.Gender = ''?'''
		END	
		
		SELECT @sql += ')'	
	END	

	-- Age filters 
	IF (@Include_18_to_25  = 1 OR @Include_26_to_35 = 1 OR @Include_36_to_45 = 1 OR @Include_46_to_65 = 1 OR @Include_66_to_100 = 1)
	BEGIN
		SELECT @sql += 'AND ('

		IF (@Include_18_to_25 = 1)
			SELECT @sql += 'c.Age <= 25 ' 		
		IF (@Include_26_to_35 = 1)
		BEGIN
			IF (@Include_18_to_25 = 1)
				SELECT @sql += 'OR c.Age BETWEEN 26 AND 35' 
			ELSE
				SELECT @sql += 'c.Age BETWEEN 26 AND 35' 
		END
		IF (@Include_36_to_45 = 1)
		BEGIN
			IF (@Include_18_to_25 = 1 OR @Include_26_to_35 = 1)
				SELECT @sql += 'OR c.Age BETWEEN 36 AND 45'
			ELSE
				SELECT @sql += 'c.Age BETWEEN 36 AND 45' 
		END
		IF (@Include_46_to_65 = 1)
		BEGIN
			IF (@Include_18_to_25 = 1 OR @Include_26_to_35 = 1 OR @Include_36_to_45 = 1)
				SELECT @sql += 'OR c.Age BETWEEN 46 AND 65'
			ELSE
				SELECT @sql += 'c.Age BETWEEN 46 AND 65'
		END
		IF (@Include_66_to_100 = 1)
		BEGIN
			IF (@Include_18_to_25 = 1 OR @Include_26_to_35 = 1 OR @Include_36_to_45 = 1 OR @Include_46_to_65 = 1)
				SELECT @sql += 'OR c.Age >= 66'
			ELSE
				SELECT @sql += 'c.Age >= 66'
		END
			
		SELECT @sql += ')'	
	END

	IF (@StartDate IS NOT NULL)
	BEGIN
		SELECT @sql += 'AND ( t.StartDateTime >= ''' + CAST(@StartDate AS VARCHAR) + ''')'
	END
	
	SELECT @sql += 'GROUP BY t.cellLong, t.cellLat' 

	EXECUTE sp_Executesql @sql,
	 N'@IncludeMale			BIT,
	   @IncludeFemale		BIT,
	   @IncludeUnknowGender BIT, 
	   @Include_18_to_25	BIT,
	   @Include_26_to_35	BIT,
	   @Include_36_to_45	BIT,
	   @Include_46_to_65	BIT,
	   @Include_66_to_100	BIT,
	   @StartDate    DATETIME2',
	   @IncludeMale, @IncludeFemale, @IncludeUnknowGender, @Include_18_to_25,
	   @Include_26_to_35,@Include_36_to_45, @Include_46_to_65, @Include_66_to_100,
	   @StartDate
END



