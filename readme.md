Ons project bestaat uit een agent, de kubus, die langs 2 kanten bewegende balken moet ontwijken door te springen. De kubus is geplaatst op een kruispunt waar de balken langs beide kanten samenkomen.
De kubus maakt gebruik van een Ray Perception Sensor 3D om rond zich te kunnen zien wat er gebeurt. De kubus zal worden beloond wanneer hij over de balken springt. Wanneer hij van het platform valt zal hij worden afgestraft. Er is ook een kleine afstraffing wanneer de kubus springt. Dit is om te voorkomen dat de kubus onnodig veel springt.
We maken gebruik van een raycast om te controleren wanneer er een obstakel zich onder de kubus bevindt. Dit is om te kunnen weten wanneer de kubus over een obstakel is gesprongen.
De obstakels maken gebruik van een script dat ze naar voor laat bewegen. In de startfunctie van het script wordt een obstakel aangemaakt met een willekeurige snelheid en hoogte. De updatefunctie zorgt ervoor dat het obstakel beweegt en zal de startfunctie aanroepen wanneer de balk een z-positie (voor de tweede balk is dit de x-positie) van minder dan -10 heeft.
We maken gebruik van twee obstacle scripts aangezien de obstakels van verschillende richtingen moeten komen en een andere startpositie hebben.
Om te voorkomen dat de obstakels met elkaar colliden hebben we deze samen in een aparte layer geplaatst. Objecten in deze layer negeren collision met elkaar maar zullen wel colliden met objecten in andere layers, in dit geval onze kubus.
