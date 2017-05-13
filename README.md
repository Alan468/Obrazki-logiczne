# Obrazki-logiczne
Aplikacja do rozwiązywania obrazków logicznych (http://pl.wikipedia.org/wiki/Obrazek_logiczny) metodą BruteForce z następującą funkcjonalnością:
- wczytanie definicji obrazu z pliku XML,
- zapis rozwiązania do bitmapy (zapisywana w lokacji uruchomienia aplikacji,
- wizualizacja rozwiązywania obrazka,
- możliwość określenia definicji obrazka z UI.

Dodatkowo:
+ zapis definicji określonej z UI do XML
<br>
Ilość kombinacji:<br>
Każde pole może znajdować w jednym z 2 stanów (puste/pełne).<br>
Przy obrazku o wysokości H i szerokości W istnieje 2^(HxW) kombinacji.<br>
<br><br>
Metoda BruteForce:<br>
Badanie każdej możliwej kombicaji do czasu znalezienia poprawnego układu. Najprostrzy i w najgorszym w wypadku (gdy rozwiązaniem jest ostatnia możliwa kombinacja) najwolniejszy. Jeśli rozwiązanie istniej to je znajdzie.<br>

Czas zbadania wszystkich kombinacji dla zadanej ilości pól:

| Ilość pól  | Ilość kombinacji | Czas (mls) | Czas (sec) |
| ------------- | ------------- | ------------- | ------------- |
| 1  | 2 | 10 | 0,01 |
| 2  | 4 | 50 | 0,05 |
| 3  | 8 | 120 | 0,12 |
| 4  | 16 | 260 | 0,26 |
| 5  | 32 | 500 | 0,5 |
| 6  | 64 | 1000 | 1 |
| 7  | 128 | 2000 | 2 |
| 8  | 256 | 4000 | 4 |
| 9  | 512 | 8000 | 8 |
| 10  | 1024 | 16000 | 16 |
| 15  | 512000 | 512 | 8,53 |
| 20  | 1048576 | 16384000 | 16384 |
| 25  | 33554432 | 524288000 | 524288 |
<br>
Lepsze metody rozwiązywania:<br>

- Algorytmy genetyczne
- Wykorzystanie grup z jednej z osi
