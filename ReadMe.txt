Setup
-----
please edit rows 20 and 21 in Program.cs if different directory / filename needed
currently set to 
C:\BnppTest\PortfolioPayments.csv

Assumptions
-----------
output is from json as specified and does not include PortfolioId
output uses column names that are pascal case rather than json names supplied - this is set in attributes in Models/Payment.cs
json format is not verified - could be done using Newtonsoft library
assume file sizes small so have left processing as synchronous

Notes
-----
have used Nuget packages NewtonSoft and CsvHelper

errors while getting json for a portfolio are trapped and processing for rest of portfolios continues
all other errors stop processing

Best regards

Jan Kool
10/02/2020
