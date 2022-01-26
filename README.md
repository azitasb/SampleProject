# Benutzerprofile - Sabahat

## Beschreibung

* Dieses in MVC geschriebene Projekt liest die Liste der Benutzer zusammen mit ihrer Job-Ebene über die API aus einer csv-Datei im Stammordner des Projekts und wird auf der Seite mit AngularJS angezeigt.
* Eine andere API fügt der Datenquelle einen zusätzlichen Datensatz hinzu.

## Technologien 

* Asp.net Web API 2
* Asp.net MVC 5
* SimpleInjector 5.3.2
* SimpleInjector.Integration.WebApi 5.0.0
* Microsoft.AspNet.Web.Optimization 1.1.3
* Newtonsoft.Json 6.0.4
* angularjs 1.8.2
* Angular.UI.Bootstrap  2.5.0
* Bootstrap 3.0.0
* CSS , HTML

## Einzelheiten

* Das Projekt ist geschichtet.
* Der Zugriff auf die Datensätze oder auf die zugreifende Klasse wird über Dependency Injection gehandhabt.
* Dependency Injection wird von der Bibliothek Simple Injector gelöst
* Um die Daten in der Datenquelle zu lesen, wurden zusätzliche Operationen an den Datensätzen durchgeführt:
	* Die Datensätze aller Dateien in diesem Ordner werden gelesen und angezeigt.
	* Leere Felder in unvollständigen Datensätzen
	* Spalten mit zwei Feldern
	* Die Zahlen in der letzten Spalte sollten der folgenden Job-Ebene entsprechen:
	
| id | Job-Ebene 
| -- | ------------ 
| 1	 | Junior		   
| 2	 | Mid-Level	       
| 3	 | Senior	   
| 4	 | Staff  
| 5	 | Manager  
| 6	 | CTO  
| 7	 | CEO  
	
	
	