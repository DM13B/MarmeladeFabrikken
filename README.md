# MarmeladeFabrikken

DM13B Integration projekt.

## God skik og brug

Hver gruppe skal udpege en "GitHub master" der kan hjælpe de andre i gruppen hvis der er problemer. Så hvis du har problemer med et eller flere af nedenstående punkter, så spørg gruppens GH master.

Vi er mange der arbejder i samme repo, og da GitHub sender notifikationer via email hver gang nogen opretter et nyt issue og nyt pull request kan det blive til en del spam. Men lad være med at blokere emails fra GitHub - vælg i stedet at "[unwatche](https://help.github.com/articles/watching-repositories)" repo'et. Så modtager du kun emails når du (eller din gruppe) bliver @nævnt.

Et par punkter til det daglige arbejde:

- Når du går i gang med en ny feature, så lav en ny branch ud fra master.
- Sørg for tit - helst hver dag - at merge master ind i din egen branch (husk at du skal synce master først). Så holder du løbende din kode up-to-date og undgår store, uoverskuelige merge konflikter. 
- Når du er færdig med din feature, skal den merges ind i master. **Dette gøres via et [pull request](https://help.github.com/articles/using-pull-requests)**. Så kan vi nemt hjælpe hinanden med at sikre kvaliteten af vores arbejde.
- Man må ikke merge et pull request før der er udført kvalitetskontrol. For hvert pull request skal gælde:
    - Koden overholder kodestandarden.
    - Koden kan bygges / kompileres.
    - Ingen tests fejler.
    - Der er 80 - 90% code coverage.
    - Din branch skal være up-to-date med master (der må ikke være nogen ændringer i master siden master blev merget ind i din branch sidst).
- Brug pull request'et til at dokumentere at der er udført kvalitetskontrol. Når du har læst en andens kode igennem og tjekket at kodestandarden er overholdt, så skriv det i en kommentar. Gør det samme når du har bygget koden og kørt alle testene.
- Hvis der en nogen du specifikt gerne vil have tjekker dit pull request, så [nævn dem](https://github.com/blog/821-mention-somebody-they-re-notified) i beskrivelsen. Du kan nævne hele din egen gruppe med @dm13b/gruppe-x, hvor x'et er din gruppes nummer (kan ses [her](https://github.com/orgs/DM13B/teams)). Det er desværre ikke muligt at nævne grupper man ikke er medlem af, så hvis du skal have fat i nogen fra en anden gruppe så nævn dem med deres brugernavn.
- Hvis du ændrer kode der tilhører et andet hold så **skal** du nævne en fra det andet hold i dit pull request.
