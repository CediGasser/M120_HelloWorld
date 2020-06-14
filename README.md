# Hello World
Eine Projektarbeit mit MVVM und WPF

## Inhaltsverzeichnis
[]()

## Einführung
Mit diesem Projekt wollen wir das gelernte von Modul 120 (Benutzerschnittstellen implementieren) und Modul 226B (Objektorientiert implementieren) widergeben. Wir wollten ein “Clicker Game” erstellen.
### Projekt
- Contributors: Vincent Dittli & Cedric Gasser
- Anlass: Modul 120 & 226B
- Startdatum: 22.05.2020
- Enddatum: -
### Tagesjournale
Die Tagesjournale können unter folgendem Link gefunden werden: [Tagesjournale](/Tagesjournale)
## Planung
### User-Stories
#### Hello World ausgeben
    Als       Spieler  
    Kann ich  Auf einen Button klicken  
    um        ein Hello World auszugeben und ein Karma zu bekommen.  
- Einen Button zum klicken, welcher das Karma erhöt und ein Hello World “printed” 
- Ein Feld, welches jedes Hello World “printed” 
- Die Anzahl Karma sollte angezeigt werden 
- Die Anzahl Hello World per Second sollte angezeigt werden 
    
#### Shop
    Als       Spieler  
    Kann ich  Im Shop Devices kaufen  
    um        mehr Hello World’s automatisch zu generieren. 
- Alle Devices welche exisitieren werden aufgelistet 
- Neben dem device Namen steht der Preis in Karma, die Hello World per Second und die Anzahl wie viel du besitzt 
- Es hat einen Buy Button, welcher dir ein Device kauft und die Anzahl wie viel du besitzt erhöht 
    
#### Hamburger-Menü
    Als       Spieler  
    Kann ich  Das Menu öffnen  
    um        Den Spielstand zu speichern oder zum Menu/Desktop zurückzukehren.  
- Das Fenster ist im Vordergrund und kann nicht in den Hintergrund 
- Es hat einen Button, welcher beim klicken den Spielstand in ein File Speichert und dich auf das Start Menu weiterleitet 
    
#### Start-Menü
    Als       Spieler  
    Kann ich  Das Start Menu öffnen / Das Spiel starten  
    um        Ein neues Spiel zu starten oder einen bestehenden Spielstand zu laden.  
- Es hat einen Button, welcher ein neues Spiel erstellt. 
- Es hat einen Button, welcher ein bestehender Spielstand lädt 
- Es hat einen Button, welcher das Programm beendet 
    
#### Daten Laden 
    Als       Spieler  
    Kann ich  Json Files ändern  
    um        ein neues Spiel zu starten oder einen bestehenden Spielstand zu laden.  
- Beim Starten vom Programm, werden die Objekte welche Hello Worlds produzieren von einem Jsonfile geladen. 
- Jeder der das File bearbeiten darf, kann somit neue Objekte Hinzufügen oder alte löschen. 

### Arbeitspaketeeinteilung
`tbd`

### Prototyp
Um uns über MVVM und WPF zu informieren, und ein Grundverständnis einer solchen Applikation zu bekommen, haben wir einen Prototyp angefertigt. Dieser soll einfach eine kleine WPF Applikation nach dem MVVM-Pattern darstellen.


### Konzept
Mit dem Grundprinzip ausgearbeitet, wollten wir das Thema und genäuere Funktionen für unser Game festlegen:  
- Man ist eine AI und möchte “Hello World” ausgeben. 
- Für jedes ausgegebene “Hello World” bekommt man Karma, Karma ist die Währung. 
- Am Anfang muss man print(“Hello World”) in einer Konsole eingeben. 
- Mit Upgrades kann aus der Konsole ein GUI mit einem Button werden damit es schneller geht. 
- Irgendwann kann man sich ein Programm kaufen, mit welchem automatisch “Hello World” ausgegeben wird. 
- Sobald man genügend “Hello World”s pro Sekunde hat, wird das Heimnetzwerk freigeschaltet. (Im Shop sind nun andere Geräte verfügbar) 
- Mit genügend Karma kann man andere Geräte kaufen, und dort “Hello World” ausgeben.  
- Eventuell steigen die Kosten für Devices, je nach dem wieviele man davon hat.

## GUI
### Startmenü
#### Startmenü -View
![Startmenü-View][Startmenu]
Bei Programmstart soll dieses View angezeigt werden. Von hier kann eine neues Spiel gestartet werden, oder ein bestehender Spielstand geladen werden.
| Element | Zweck |
|--|--|
| Neues Spiel - Button | Erstellt ein neues Spiel und zeigt die GameView an. |
| Spiel Laden - Button | Zeigt eine View mit den gesicherten Spielständen an. |
| Beenden - Button | Mit diesem Button soll das Programm beendet werden können. |
| GitHub Link - Button | Einen Button um auf dieses GitHub Repository zu linken. |

#### Spiel laden -View
![Spiel laden-View][Spiel laden]
Wenn ein vorhandener Spielstand geladen werden soll, wird in diesem View eine Liste mit den vorhandenen Spielständen gezeigt. Eventuell kann man hier auch die Namen der Spielstände anpassen. Standardmässig soll ein Spielstand mit Datum und Uhrzeit als Namen gespeicher werden.
| Element | Zweck |
|--|--|
| Zurück - Button | Um wieder zum Startmenü zu kommen, falls man nun doch ein neues Spiel anfangen will. |
| Liste | In dieser Liste werden alle vorhandenen Spielstände, vermutlich aus einem Ordner, angezeigt. |
| Listen Element | Stellt einen Spielstand dar. Dieser Spielstand kann auch geladen werden. |

### Im Spiel
#### Game -View
![Game-View][Game]
Diese View soll die Hauptview während eines Spiels sein. Hier sollen die wichtigsten Informationen wie Hello World pro Sekunde oder Totales Karma angezeigt werden.
| Element | Zweck |
|--|--|
| Hello World - Button | Mit diesem Button wird ein “Hello World!” ausgegeben. |
| Ausgabeterminal | Hier werden alle “Hello World!” ausgegeben, zum Darstellen was gerade passiert. |
| HW/s - Anzeige | Zeigt an, wieviel “Hello World!” pro Sekunde von den gekauften Devices produziert werden. |
| Karma - Anzeige | Zeigt an wieviel Karma man hat. |
| Shop - Button | Mit diesem Button wird der Shop mit einer Liste aller Devices angezeigt, die man kaufen kann. |
| Menu - Button | Über diesen Button wird ein kleines Menu angezeigt, in welchem man den Spielstand speichern kann oder das Spiel beenden kann. |

#### Konsole -View
![Konsole-View][Konsole]
Bei einem neuen Spiel wird noch vor der GameView diese View angezeigt. Diese View soll als Intro dazu dienen die Story des Games besser darzustellen. Man soll zuerst mit einer Konsolenapplikation anfangen und mit der Zeit eine Graphische Benutzeroberfläche bekommen. Diese View kann grundsätzlich das gleiche ViewModel wie die GameView brauchen, da das Selbe einfach anders dargestellt wird. Funktionen werden ausgeführt, indem Befehle in die Konsole eingegeben werden.
| Element | Zweck |
|--|--|
| Konsolenheader | Zeigt aktuelles Karma und die möglichen Befehle an |
| Eingabebereich Können | die Befehle, die im Header angegeben sind, eingegeben werden.  
| >print “Hello World!” | Befehl der ein Hello World ausgibt, damit bekommt man 1 Karma 
| >upgrade | Sobald genügend Karma vorhanden ist, kann mit diesem Befehl von dem KonsolenView zu dem eigentlichen GameView gewechselt werden 
| >exit | Das Spiel wird beendet, aber nicht gespeichert, denn bei einem Spielstand wo man noch immer im KonsolenView ist, lohnt es sich nicht zu speichern. 

#### Shop -View
![Shop-View][Shop]
In dieser View werden alle Devices aufgelistet. Devices die nicht gekauft werden können weil man zu wenig Karma hat, werden ausgegraut. 
| Element | Zweck |
|--|--|
| Device Liste | Hier werden alle Devices aufgelistet. |
| HWps | Zeigt an wieviel Hello World pro Sekunde ein solches Device Produziert |
| Price | Die Kosten für ein solches Device |
| Buy - Button | Mit diesem Button kann man ein solches Device kaufen, vorausgesetzt man hat genügen Karma |
| Zurück - Button | So kann man aus dem Shop wieder auf die GameView kommen |

#### Hamburgermenü -View
![Hamburgermenü-View][Burgermenu]
Diese View soll wenn möglich als Overlay dargestellt werden, sonst als feste Page so wie alle anderen Views. 
| Element | Zweck |
|--|--|
| Resume - Button | Mit dem Spiel weiterfahren, also zurück auf das GameView gehen. |
| Spielstand Speichern - Button | Der Spielstand soll gespeichert werden, und man soll wieder auf die GameView kommen. |
| Spiel speichern zum Hauptmenü - Button | Das Spiel soll gespeichert werden, und das Startmenü soll angezeigt werden. |

### Prozessdiagramm
![BPMN Prozessdiagramm mit BizAgi-Modeler gemacht][Prozessdiagramm]

## Entwicklung
### Voraussetzungen / Programme
### UML - Diagramm
### Fody (PropertyChanged)
### Codebeispiele


[Startmenu]: /res/Hauptmenu.PNG
[Spiel laden]:_/res/Spielladen.PNG
[Game]: /res/GameView.PNG
[Konsole]: /res/ConsoleView.PNG
[Shop]: /res/ShopView.PNG
[Burgermenu]: /res/Burgermenu.PNG


[Prozessdiagramm]: /res/Prozessdiagramm.PNG


