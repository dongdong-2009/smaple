create view vAllCompany
as 
 select companyid,companyname from company union all select companyid,companyname from asiacompany   
      union select companyid,companyname from Company_Okooo  
      union select CompanyID,companyname from company_500  
