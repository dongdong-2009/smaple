use assetdm


--update assetdm.ams.location set AMLOCATION_ADDRESS1 = 'Capriata Localitd Pedaggera' where AMLOCATION_ADDRESS1 like '%Capriata%Localit%Pedaggera%'

;WITH AllNumbers AS
(   SELECT 1 AS Number
    UNION ALL
    SELECT Number+1
        FROM AllNumbers
        WHERE Number<1000
)
SELECT 
      distinct AMLOCATION_BARCODE , CONVERT(nvarchar(300),AMLOCATION_ADDRESS1) AS BadValue --make the XYZ in convert(varchar(XYZ), ...) the largest value of col1, col2, col3
    FROM assetdm.ams.location           y
        INNER JOIN AllNumbers n ON n.Number <= LEN(y.AMLOCATION_ADDRESS1)
    WHERE ASCII(SUBSTRING(y.AMLOCATION_ADDRESS1, n.Number, 1))<32 OR ASCII(SUBSTRING(y.AMLOCATION_ADDRESS1, n.Number, 1))>127

order by 1
OPTION (MAXRECURSION 1000)


--bad characters
SELECT distinct [address 1] from AssetDM.ams.[ABE_AssetBillingData_View] (NOLOCK) WHERE (AMASSET_DINSTALL BETWEEN 'Jan  1 1997 12:00AM' AND 'Oct 24 2016 11:59PM')AND Assignment NOT LIKE ( 'Retired%consumed%')AND [Client Identification] IN ('KRFG')AND Assignment IN ('IN USE')
and  [address 1]  != cast([address 1] as varchar(1000))




SELECT distinct AMASSET_HP_ASSET_TAG from AssetDM.ams.assetcenter (NOLOCK) 
WHERE  AMASSET_HP_ASSET_TAG  != cast(AMASSET_HP_ASSET_TAG as varchar(1000))

