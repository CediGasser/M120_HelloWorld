# Hello World
_Eine Projektarbeit mit MVVM und WPF_

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
| Task | Bearbeiter | Status |
|--|--|--|
| Mockup mit Adobe XD | Vincent | Fertig |
| User Stories | Vincent & Cedric | Fertig |
| Repository anlegen | Cedric | Fertig |
| Prototyp erstellen | Vincent & Cedric | Fertig |
| Konzept erstellen | Vincent | Ongoing |
| Dokumentation zu GitHub in MarkDown übernehmen | Cedric | Fertig |
| Bedienkonzept zu Mockup | Cedric | Fertig |
| Startmenü Views umsetzen | Vincent | Fertig |
| Spiel-Views umsetzen | Vincent | Fertig |
| UML für Model definieren | Vincent & Cedric | Ongoing |
| Feature-Hello_World_ausgeben | Vincent | Ongoing |
| Feature-Startmenü | Cedric | Ongoing |
| Feature-Shop | Vincent | - |
| Feature-Hamburgermenü | Vincent | - |
| Feature-Daten_laden | Cedric | - |
| UML wenn nötig anpassen & Model besprechen | Vincent & Cedric | - |
| Testing | Vincent & Cedric | - |

### Prototyp
Um uns über MVVM und WPF zu informieren, und ein Grundverständnis einer solchen Applikation zu bekommen, haben wir einen [Prototyp](/Prototyp) angefertigt. Dieser soll einfach eine kleine WPF Applikation nach dem MVVM-Pattern darstellen.

### Referenzen (Tutorials)
Wir waren begeistert von MVVM als wir genäuer darüber gelesen haben. MVVM ist unserer Meinung nach um einiges besser als MVC, einfach schon weil dort mehr Sachen genäuer definiert sind und weil die lose Kopplung von View und ViewModel ein unabhängigeres Entwickeln ermöglichen. Wir haben auch noch einige andere Tutorial überflogen.
- [Wikipedia Artikel](https://de.wikipedia.org/wiki/Model_View_ViewModel#:~:text=Model%20View%20ViewModel%20(MVVM)%20ist,Logik%20der%20Benutzerschnittstelle%20(UI).)
- [LinekdIn Tutorial](https://www.linkedin.com/learning/einfuhrung-in-die-softwarearchitektur-2-architekturmuster/was-ist-mvvm?u=2976210)
- [YouTube Tutorial](https://www.youtube.com/watch?v=EpGvqVtSYjs)

Jedoch hatten wir einige Probleme bei der Codetechnischen umsetzung vom Prototypen, vorallem weil wir keine Ahnung von Events und Delegates hatten. Der Ausbildner von Vincent und diese YouTube Tutorials halfen uns zu verstehen wie Events funktionieren.
- [Events und Delegates](https://youtu.be/jQgwEsJISy0?)
- [Delegates](https://www.youtube.com/watch?v=G5R4C8BLEOc)
- [Events](https://www.youtube.com/watch?v=TdiN18PR4zk)

Wir hörten auch, dass Noah und Nick ihre Dokumentation mit Markdown auf GitHub erstellen. Wir haben uns bei Ihnen erkundigt und waren überzeugt von Markdown. Zu unserem Vorteil war Mark Down ziemlich schnell zu lernen und somit konnten wir unsere Dokumentation auf GitHub übernehmen.
- [10 Minuten Markdown Tutorial](https://www.markdowntutorial.com/)
- [GitHub Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)
- [Alte Word-Dokumentation](res/Dokumentation.docx)

Alls wir langsam, vielleich auch ein bisschen knapp in die MVVM, WPF und Git Prinzipien reinkamen, bemerkten wir erst unsere "richtigen Probleme". Zum Beispiel wie man mit MVVM ein Button Klick handelt. Zum Glück hatte Vincent's Oberstift ein paar Tips gegeben und sein Projekt zur abschau freigegeben. Dank diesen Tips und der Vorlage, fügten wir ein Ordner Infrastruktur hinzu, in welcher wir die Command Klassen von MyToolkit hinzufügten. Danach waren die Commands kein Hindernis mehr.
- [MyToolkit](https://github.com/MyToolkit/MyToolkit/blob/master/LICENSE.md)

Das nächste Problem war, dass wir alle Devices in einer ListView auflisten wollten, und einen Button haben, welcher das spezifische Device ändern sollte. Dafür haben wir ein duzend Websites angeschaut, und nur eine Gefunden, welche das Zeugs erklärt. Bei allen anderen war das Problem, dass wir nicht genau angegeben haben, was wir wollten und deshalb hat es uns auch Zeugs vorgeschlagen, welches wir nicht wollten.
- [Command in ListView](https://codeblitz.wordpress.com/2009/03/17/wpf-commands-part-3-custom-routeduicommand/)

Ein weiterer Baustein war der Timer. Um zu berechnen, wie vielle HelloWorlds wir per Seckunde produzieren, brauchten wir einen Timer, der jede Sekunde ein Event erstellte. Nach langem informieren, war unsere beste Lösung ein Dispatcher Timer. Als wir das entschieden hatten, ging es eigentlich recht ring zum implementieren.
- [Dispatcher Timer](https://docs.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatchertimer?redirectedfrom=MSDN&view=netcore-3.1)

Das Speichern und Laden vom JSON File ging erstaunlich leicht. Das einzige Problem war, dass es Keine Interfaces speichern und laden kann. Deshalb haben wir das Interface IHelloWorldProducer entfernt, und einfach die Klasse Devices benutzt. Da wir sowieso kein anderen HelloWorldProducer hatten war das kein Problem, ausser dass der Code nicht so leicht erweiterbar ist.
- [Load and Save JSON File](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to)

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
| Load Game - Button | Zeigt eine View mit den gesicherten Spielständen an. |
| New Game - Button | Erstellt ein neues Spiel und zeigt die GameView an. |
| Exit - Button | Mit diesem Button soll das Programm beendet werden können. |
| GitHub Link - Button | (Optional) Einen Button um auf dieses GitHub Repository zu linken. |

#### Spiel laden -View
![Spiel laden-View][Spiel laden]  
Wenn ein vorhandener Spielstand geladen werden soll, wird in diesem View eine Liste mit den vorhandenen Spielständen gezeigt. Eventuell kann man hier auch die Namen der Spielstände anpassen. Standardmässig soll ein Spielstand mit Datum und Uhrzeit als Namen gespeicher werden.
| Element | Zweck |
|--|--|
| Zurück - Button | Um wieder zum Startmenü zu kommen, falls man nun doch ein neues Spiel anfangen will. |
| Liste | In dieser Liste werden alle vorhandenen Spielstände, vermutlich aus einem Ordner, angezeigt. |
| Listen Element | Stellt einen Spielstand dar. Dieser Spielstand kann auch geladen werden. |
| Load Game | Damit kann der Ensprechende Spielstand geladen werden, und die GameView wird geöffnet. |
| Delete Game | So kann ein Spielstand gelöscht werden. |

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
| Options - Button | Optionen anzeigen |
| Save and Exit - Button | Das Spiel soll gespeichert werden, und das Startmenü soll angezeigt werden. |

### Prozessdiagramm
![BPMN Prozessdiagramm mit BizAgi-Modeler gemacht][Prozessdiagramm]  

## Entwicklung
### Voraussetzungen / Programme
### UML - Diagramm
### Fody (PropertyChanged)
Fody ist ein Nuggetpack welches sehr viele Erweiterungen für Visual Studio beinhaltet. 
Wir brauchen nur Fody propertychanged. Dieses Nugget generiert den Code nach dem er Gebuildet wird. Das heisst, er verändert die Intermediate Language. Ein Beispiel wäre die set-methode: 
````c#
    public string Title { get; set; }
````
Dieser code wird wegen dem Fody in der Intermediate Language zum Equivalent von:
````c#
    public string Title 
    { 
        get => this.title 
        set
        {
            if (value != this.title)
            {
                this.title = value;
                this.NotifyPropertyChanged();
            }
        }
    }
````



### Codebeispiele


[Startmenu]: /res/Hauptmenu.PNG
[Spiel laden]: /res/Spielladen.PNG
[Game]: /res/GameView.png
[Konsole]: /res/ConsoleView.png
[Shop]: /res/ShopView.png
[Burgermenu]: /res/Burgermenu.png

[Prozessdiagramm]: /res/Prozessdiagramm.PNG


