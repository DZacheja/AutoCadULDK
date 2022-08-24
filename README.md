# AutoCadULDK
Pobieranie plików z serwisu ULDK bezpośrednio do programu AutoCAD<br>
[strona](https://uldk.gugik.gov.pl/) serwisu i pełna [dokumentacja](https://uldk.gugik.gov.pl/opis.html)

## Opis programu
Program pobiera poligony reprezentujące województwa, powiaty, gminy, obręby lub pojedyncze działki z usługi lokalizacji działek kastralnych (ULDK).<br>
Wewnątrz każdego obiektu znajduje się blok zawierający opis obiektu. Znajdują się w nim wszystkie dostępne w serwisie informacje:
<p align=left>
<img src ="https://user-images.githubusercontent.com/72301310/186378075-fd584bed-762e-4546-a9d2-75c0ca2c9013.png" Width=400>
</p>
W odróżnieniu od innych zastosowań oprcaowano pobieranie wszystkich działek ze wskazanego zakresu.<br>

### Schemat algorytmu wygląda następująco:<br>

1. Zaznaczenie prostokąta:
<p align=left>
<img src ="https://user-images.githubusercontent.com/72301310/186372136-530fc308-f3f9-41e1-b77b-b5097129f25a.png" Width=400>
</p>

2. Pobranie pierwszej działki:
<p align=left>
<img src ="https://user-images.githubusercontent.com/72301310/186373177-ea560d1d-4113-42a4-b53e-5c9544c5ef7f.png" Width=400>
</p>

3. Obliczenie nowego zakresu pobierania:
<p align=left>
<img src ="https://user-images.githubusercontent.com/72301310/186374230-0259fdba-85b7-4843-a9f0-b23d2d689c39.png" Width=400>
</p>

4. Pobieranie kolejnych działek w jednym fragmencie:
<p align=left>
<img src ="https://user-images.githubusercontent.com/72301310/186375357-d48c4452-7c06-452f-90a0-06f235a8831d.png" Width=400>
</p>

5. Po pobraniu działek w danym fragmencie rozpoczyna się pobieranie w kolejnym i tak do mementu uzyskania pełnego wypełnienia
<p align=left>
<img src ="https://user-images.githubusercontent.com/72301310/186376606-923ba98e-c765-434f-b2c9-197d3f8efa50.png" Width=400>
</p>

6. Algorytm kończy pracę gdy wszystkie działki zostaną pobrane.
<p align=left>
<img src ="https://user-images.githubusercontent.com/72301310/186377158-fe7052d3-a1bd-48e3-a400-5cb75601dde4.png" Width=400>
</p>

## Instalacja
Po pobraniu wersji release lub zbudowaniu projektu należy użyć komendy <b>WCZYTAJNET</b> lub <b>NETLOAD</b> w programie AutoCAD.
Następnie wskazujemy na dysku plik <b>AutoCadULDK.dll</b>. Jeżeli wczytano program pomyślnie w AutoCAD powinna być dostępna nowa komenda <b>ULDK</b> otwierająca okno główne.<br>

#### Prezentacja wideo wczytywania:

https://user-images.githubusercontent.com/72301310/186378651-fed1502d-b1c7-465f-822e-fbdbb666144d.mp4

## Opis wszystkich funkcjonalności

Prezentacja wszystkich dostępnych funkcji wraz z instruktażem wideo.<br>
<b>Przed rozpoczęciem pobierania upewnij się czy wybrany jest odpowiedni układ współrzędnych oraz rodzaj pobieranego obiektu.</b>

### Pobieranie działek za pomocą identyfikatora
Pobieranie poprzez ID jest dostępne zgodnie z [parametrami](https://uldk.gugik.gov.pl/opis.html), należy jedynie wpisać numer TERYT lub nazwę w przypadku obrębu we wskazane miejsce i klinąć pobierz.

#### Prezenacja wideo pobierania z wykorzystaniem identyfikatora:

https://user-images.githubusercontent.com/72301310/186405946-d6730df1-8744-4999-b285-818786953f00.mp4


### Pobieranie poprzez wskazanie punktu

Ten sposób pobierania  polega na wskazaniu na mapie punktu, w którym zostanie pobrany obiekt. Dostępne są dwa tryby pobierania, ciągłe oraz pojedyncze. Podobnie jak w poprzednim sposobie mamy możliwość pobrania wszystkich dostępnych typów obiektów.<br>
W celu szybkiego pobrania pojedynczej działki można wykorzystać komendę <b>POBIERZULDK</b>
 

#### Prezenacja wideo pobierania na podstawie punktu

https://user-images.githubusercontent.com/72301310/186406458-988daf46-2f57-410b-b289-7db6278e8d33.mp4

### Pobieranie ze wskazanego zakresu

Metoda polega na pobraniu wszystkich działek z zakresu jak opisano [tutaj](https://github.com/DZacheja/AutoCadULDK/edit/main/README.md#schemat-algorytmu-wygl%C4%85da-nast%C4%99puj%C4%85co).

#### Prezenacja wideo pobierania z zakresu:

https://user-images.githubusercontent.com/72301310/186403354-ed6edc44-4ec6-4b33-b043-df08370cfa6d.mp4

### Pozyskanie informacji

Ostatnią funkcjonalnością jest pobranie informacji o punkcie bez pobierania geometrii obiektu, po wskazaniu punktu w oknie wyświetlą sie wszystkie dostępne w systemie informacje.
W celu szybiego pozyskania informacji bez wcześniejszego pokazywania okna programu należy skorzystać z komendy <b>INFORMACJEULDK</b><br>
Po pobraniu informacji mamy możliwość otworzenia podlądu w [geoportalu](https://www.geoportal.gov.pl/) na wskazaną działkę.

#### Prezenacja wideo pozyskania informacji:

https://user-images.githubusercontent.com/72301310/186404000-2fde6ac8-ae1d-4485-8d31-30a68f55a212.mp4


## Autor
Damian Zacheja

## Licencja
[MIT](https://github.com/DZacheja/AutoCadULDK/blob/main/LICENSE)




