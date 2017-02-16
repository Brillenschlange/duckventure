<h1>Tutorial: The Duckventure</h1>

<ol>
	<li><a href="#Nr1">Einleitung</a></li>
	<li><a href="#Nr2">Idee und Konzept</a></li>
	<li><a href="#Nr3">Einrichtung der IDE unter Windows</a></li>
		<ol>
			<li><a href="#Nr3.1">Installation Visual Studio</a></li>
			<li><a href="#Nr3.2">Installation MonoGame</a></li>
		</ol>
	<li><a href="#Nr4">Einrichten der IDE unter Linux</a></li>
		<ol>
			<li><a href="#Nr4.1">Installation der Pakete</a></li>
			<li><a href="#Nr4.2">Installation von MonoGame</a></li>
		</ol>
	<li><a href="#Nr5">Anlegen eines Projektes</a></li>
		<ol>
			<li><a href="#Nr5.1">Anlegen in Visual Studio</a></li>
			<li><a href="#Nr5.2">Anlegen in MonoDevelop</a></li>
		</ol>
</ol>


<h2 id="Nr1">1. Einleitung</h2>
<p>Dieses Tutorial bezieht sich auf die Erstellung eines 2D Jump'n'Runs. F&uuml;r die Erstellung wird das Framework MonoGame in C&#35; verwendet. In diesem Tutorial geht es um die Installation von MonoGame unter dem Betriebssystem Windows und Linux.</p>

<h2 id="Nr2">2. Idee und Konzept</h2>
<p>"<i>The Duckventure</i>" ist ein 2D Jump'n'Run, welches innerhalb des Informatikunterrichts entstanden ist. Zu diesem Zeitpunkt ist das Projekt noch in seinen Grundzügen, aber die Ersteller des Projekts sind drauf und dran es fertigzustellen.</p>
<p>Das Spiel wird sich in späteren Zügen per Tastatur (WASD) bedienen lassen. Das Konzept beläuft sich darauf, dass eine kleine Ente (eng: <i>duck</i>) durch die Welt läuft/hüpft und auf Grundlage einer spannenden Geschichte viele Abenteuer erlebt und bewältigt. Der genaue Verlauf dieser Geschichte steht noch nicht entgültig fest, aber lässt bereits auf ein vielversprechendes Projekt deuten.</p>

<h2 id="Nr3">3. Einrichtung der IDE unter Windows</h2>
<h3 id="Nr3.1">3.1. Installation Visual Studio</h3>
<p>F&uuml;r die Installation von MonoGame wird das Programm Windows Visual Studio (z.B. &quot;<i>Community 2015</i>&quot;) ben&ouml;tigt.</p>
<p>&gt;&gt;&gt;<a href="https://www.visualstudio.com/de/downloads/" target="_blank"><b>Hier downloaden</b></a>&lt;&lt;&lt;</p>
<p>Anschließend folgt man den nachstehenden Installationsanweisungen:</p>
<p>Öffnen der .exe (findbar beim Explorer unter &quot;Downloads&quot; &rarr; &quot;Downloads durchsuchen&quot; (oben rechts) &rarr; Eingabe von &quot;vs_community_DEU&quot; &rarr; Doppelklick auf die .exe)</p>
<p>Ausführen der .exe (C:\Users\User\Downloads\vs_community_DEU_969443474.1486759425.exe)</p>
<p><img src="images/idewindows/1.png"></p>
<p>Ausführen der .exe auf dem lokalen Endgerät (C:\Users\User\AppData\Local\Temp\{30189239-...)</p>
<p><img src="images/idewindows/2.png"></p>
<p>Auswahl des Installationsortes (<b>Empfehlung</b>: vorgegebenden Installationsort beibehalten) und Wahl der Installationsart. Für die Installation von MonoGame bietet sich die Installationsart &quot;<i>Standard</i>&quot; an. Bestätigen und starten der Installation mit Klick auf &quot;<i>Installieren</i>&quot;. Zu beachten ist, dass die Installation von Winows Visual Studio bis zu 8 GB auf den Laufwerken benötigen kann. Die Installationsdauer kann bis zu 80 Minuten dauern.</p>
<p><img src="images/idewindows/3.png"></p>
<p>Nach dem Abschluss der Installation erscheint ein Fenster mit &quot;<i>Setup abgeschlossen!</i>&quot;. Das Programm Windows Visual Studio ist somit auf dem Endgerät installiert. Es kann nach dem Neustart des Endgerät gestartet und verwendet werden. Mit dem Klick auf &quot;<i>Jetzt neu starten</i>&quot; wird das Endgerät neu gestartet und das Produkt gestartet.</p>
<p><img src="images/idewindows/4.png"></p>
<p>Nach dem erfolgreichen Neustart des Endgeräts öffnet sich die Internetseite von Windows Visual Studio und die Aussage &quot;<i>Welcome to Visual Studio</i>&quot; auf der Website bestätigt, dass die Installation erfolgreich verlaufen ist.</p>
<p><img src="images/idewindows/5.png"></p>

<h3 id="Nr3.2">3.2. Installation MonoGame</h3>
<p>Das Framework MonoGame muss anschließend gedownloadet und installiert werden.</p>
<p>&gt;&gt;&gt;<a href="http://www.monogame.net/downloads/" target="_blank"><b>Hier downloaden</b></a>&lt;&lt;&lt;</p>
<p>Das Öffnen und Auführen der .exe führt zu dem Installationsverlauf. Hierbei sollte man die nachstehenden Installationsanweisungen beachten:</p>
<p>Bevor man bei dem ersten Installationsfenster auf &quot;<i>Next</i>&quot; klickt, sollte man alle anderen Anwendungen schließen, damit keine Komplikationen zwischen Updates und geöffneten Anwendungen entstehen können. Nach dem Schlie&szlig;en der anderen Anwendung klickt man auf &quot;<i>Next</i>&quot;, um den Installationsvorgang fortzusetzen.</p>
<p><img src="images/idewindows/6.png"></p>
<p>Das Akzeptieren der Lizentvereinbarungen ist die Vorraussetzung zum Starten der Installation. Durch den Klick auf &quot;<i>I Agree</i>&quot; werden die Lizenzvereinbarungen akzeptiert.</p>
<p><img src="images/idewindows/7.png"></p>
<p>Im n&aulm;chsten Schritt wählt man die Komponenten der Installation aus. Im optimalen Fall sind alle möglichen Installationskomponenten ausgew&aulm;hlt. Ist dies nicht der Fall sollte man alle möglichen Komponenten mit einem Hacken versehen. Die benötigte Speicherkapazit&aulm;t auf dem Endgerät wird unten links im Fenster angezeigt. Mit dem Klick auf Install startet die Installation. Die Dauer der Installation kann bis zu 5 Minuten beanspruchen.</p>
<p><img src="images/idewindows/8.png"></p>
<p>Die Installation von MonoGame ist abgeschlossen. Mit einem Klick auf &quot;<i>Finish</i>&quot; schlie&szlig;t sich das Fenster.</p>
<p><img src="images/idewindows/9.png"></p>

<h2 id="Nr4">4. Einrichten der IDE unter Linux (Ubuntu)</h2>
<p>In der offiziellen <a href="http://www.monogame.net/documentation/?page=main" target="_blank">MonoGame-Dokumentation</a> wird die <a href="http://www.monogame.net/documentation/?page=Setting_Up_MonoGame" target="_blank">Installation</a> ebenfalls beschrieben, wir konnten bei uns nicht alle Pakete installieren, es funktionieren aber trotzdem. Im Folgenden erklären wir die dortige Anleitung, wie sie zum Zeitpunkt unseres Projektes unter MonoGame Version 3.5 abl&auml;uft.

<h3 id="Nr4.1">4.1. Installation der Pakete</h3>
<p>Folgende Pakete werden vor der Installation von MonoGame ben&ouml;tigt:</p>
<ul>
	<li>monodevelop</li>
	<li>libopenal-dev</li>
	<li>gtk-sharp3</li>
</ul>
<p>Installation unter Ubuntu im Terminal (Strg + Alt + T) mit:</p>
<p class="command">
	sudo apt install monodevelop libopenal-dev gtk-sharp3
</p>
<p><img src="images/idelinux/password.png"></p>
<p>Nachdem man das Kennwort eingegeben hat, best&auml;tigt man die auftretende Frage mit "<i>y</i>" und lässt den Computer einen Moment computen.</p>
<p><img src="images/idelinux/done.png"></p>
<p>So sollte die Ausgabe aussehen, wenn die Installation erfolgreich verlaufen ist.</p>

<h3 id="Nr4.2">4.2. Installation von MonoGame</h3>
<p>Sobald letztere Pakete installiert sind, kann MonoGame (Download <a href="http://www.monogame.net/downloads/" target="_blank">hier</a> - aktuelle Version auswählen -> MonoGame *.* for Linux) installiert werden. Dafür navigiert man im Terminal zur Datei (normalerweise im Downloadordner), macht diese ausführbar und führt sie dann aus. Folgende Befehle (Zu beachten: Jede Zeile ein neuer Befehl) sind daf&uuml;r einzugeben:</p>
<p class="command">
	cd Downloads<br>
	chmod +x monogame-sdk.run<br>
	sudo ./monogame-sdk.run<br>
</p>
<p>F&uuml;r den sudo-Befehl erneut das Passwort eingeben, die folgenden beiden Frage wieder mit "<i>Y</i>" beantworten und MonoGame wird installiert.</p>
<p><img src="images/idelinux/menu.png"></p>
<p>Nun ist die IDE MonoDevelop mit installierten MonoGame-Addin im Startmen&uuml; zu finden.</p>

<h2 id="Nr5">5. Anlegen eines Projektes</h2>
<p> Das Starten von einem MonoGame-Projekt ist von Betriebssystem zu Betriebssystem anders. Im Folgenden lassen sich die Tutorials zum Anlegen eines neuen Projektes für Windows und Linux finden.</p>

<h3 id="Nr5.1">5.1. Anlegen in Visual Studio</h3>
<p>Starten von Windows Visual Studio. Das Programm ist unter der Liste nach dem Klick auf das Windows-Logo (unten Links) zu finden.</p>
<p>Beim ersten Starten von Windows Visual Studio ist eine Anmeldung mit einem Microsoft-Account nötig, außer man möchte das Programm nur im Testzeitraum von 30 Tagen benutzen. Die Anmeldung ist kostenlos und birgt keine späteren Kosten. Falls man bereits über einen Microsoft-Account verfügt, klickt man auf &quot;<i>Anmelden</i>&quot; und vollführt die Anmeldung mit dem Namen und der E-Mail-Adresse. Anderenfalls legt man sich einen Account unter &quot;<i>Registrieren</i>&quot; an und meldet sich anschließend an.</p>
<p><img src="images/idewindows/10.png"></p>
<p>Um ein neues MonoGame-Projekt anzulegen, folgt man dem Reiter Datei -> Neu -> Projekt...
<p><img src="images/idewindows/11.png"></p>
<p>Im Fenster folgt man den Reitern Installiert -> Vorlagen -> Visual C&#35; -> MonoGame und wählt &quot;<i>MonoGame Windows Project</i>&quot; aus. Der Projektname, Speicherort und der Projektmappenname können im unteren Teil des Fensters angepasst werden. Mit dem Klick auf &quot;<i>Ok</i>&quot; wird das Projekt erstellt.</p>
<p><img src="images/idewindows/12.png"></p>

<h3 id="Nr5.2">5.2. Anlegen in MonoDevelop</h3>
<p>Unter Linux mit Monodevelop lässt sich ein Projekt relativ &auml;hnlich erstellen. Zuerst sucht man im Startmen&uuml; nach MonoGame und f&uuml;hrt es aus. Dann wird man von folgendem Interface begr&uuml;ßt:</p>
<p><img src="images/idelinux/interface.png"></p>
<p>Hier kann man unter &quot;<i>Solutions</i>&quot; auf &quot;<i>New...</i>&quot; ein neues Projekt erstellen.</p>
<p><img src="images/idelinux/newsolution.png"></p>
<p>Im n&auml;chsten Fenster wählt man links unter &quot;<i>MonoGame</i>&quot; - &quot;<i>App</i>&quot; ein &quot;<i>MonoGame Cross Platform Desktop Project</i>&quot;. Best&auml;tigen mit &quot;<i>Next</i>&quot;.</p>
<p><img src="images/idelinux/configure.png"></p>
<p>In diesem Fenster kann das Projekt benannt werden. Hierzu den gewünschten Projektnamen eingeben und den Speicherort (&quot;Location&quot;) auswählen. Mit &quot;Create&quot; (unten rechts) den Projektnamen bestätigen und das Projekt erstellen.

