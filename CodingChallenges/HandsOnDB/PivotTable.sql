Create Table Itv (Lob varchar(100),RiskInd bit);

Insert into Itv(Lob, RiskInd) Values ('SW', 1);
Insert into Itv(Lob, RiskInd) Values ('PF', 0)
Insert into Itv(Lob, RiskInd) Values ('COP', 1)

Select Lob, RiskInd from Itv;


select SW 'SW RiskInd', PF 'PF RiskInd', COP 'COP RiskInd' from 
 (Select Lob, CAST(RiskInd As Int) as RiskInd from Itv) As Source 
  Pivot(Min(RiskInd) For Lob IN (SW, PF, COP)) As PivotTable