<!-- 
-Przycisk odczytu ostatniego rekordu z bazy
-przyciśk pobrania arkusza ze strony + pomiar czasu od ostatniego strału
-dwa wykresy na jednym
-pobrać liste spółek do bazy
-wybór spółki z selectlisty dla której należy pobrać arkusz ze strony lub bazy
-ustawianie zakresu pobieranych danych
-wykres zmian względem poprzedniego dnia w zakresie 20% odceny aktualnej(suma zleceń kupna , suma zleceń sprzedaży)
-chartjs/syncfusion
-wyświetlanie wszystkich informacji po pobraniu danych danej spółki

 -->

<!-- 
Scrapper
-Metoda  do pobrania orderbooka (symbol spółki)

 -->
 <!-- 
 Controller
 @Metoda pobierająca cały arkusz
  -->

  <!-- 
  Blazor
  -mapowanie na Ask\BidOrderbook.orders
  -Wykres z ask/bid
   -->
   <!-- 
   UI
   Menu:
    -Arkusz zleceń
    -PAP- komunikaty
    -arkusz tranzakcji pakietowych
    -procentowej ilości pozycji krótkich z  knf
    -google trends(jeśli ma być czuła na skoki procentowe odniesienie do poprzedniego dnia),
    -bankier ???
    -->

    Pomysły:
    -Oblicznie liczby kupujących, sprzedających + wykres (Wzrost liczby kupujących = wzrost ceny)


    Propercje:
        -cena
        -zmiana zł
        -zmiana %
        -wartośc obrotu
    
    Połączenia:
        -histogram z arkusza zleceń (na jakiej kwocie/przedziale najwięcej zleceń)
        -PAP- komunikaty,
        -google trends(jeśli ma być czuła na skoki procentowe odniesienie do poprzedniego dnia),
        -procentowej ilości pozycji krótkich z  knf
        -arkusz zleceń https://gragieldowa.pl/spolka_arkusz_zl/spolka/CDR/typ/0 - żeby sprawdzić czy dno jest uklepane (obliczać i wykożystać procentowy udział względem wszytkich akcji)
        -arkusz tranzakcji pakietowych https://www.gpw.pl/transakcje-pakietowe
        -bankier ???