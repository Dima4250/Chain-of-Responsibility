Понятие паттернов проектирования:

Паттерны — это типовые решения распространённых проблем в проектировании ПО. Они помогают создавать гибкий, поддерживаемый и масштабируемый код.

Паттерны проектирования делятся на следующие категории:

1. Архитектурные - определяют общую структуру системы, разделяя её на подсистемы и описывая их взаимодействие.

2. Порождающие - шаблоны проектирования, которые абстрагируют процесс создания объектов. Они позволяют сделать систему независимой от способа создания, композиции и представления объектов.

3. Структурные - шаблоны проектирования, в которых рассматривается вопрос о том, как из классов и объектов образуются более крупные структуры.

4. Поведенческие - шаблоны проектирования, определяющие алгоритмы и способы реализации взаимодействия различных объектов и классов.

5. Идиомы - низкоуровневые решения типовых задач реализации, например очистка мусора - Disposable().

Паттерн Chain of Responsibility (Цепочка обязанностей)
Тип: Поведенческий паттерн
Назначение: Позволяет передавать запросы последовательно по цепочке обработчиков, пока один из них не обработает запрос.

Описание:
- Handler - интерфейс обработчика
- ConcreteHandler - конкретные обработчики
- Client - инициирует запрос и запускает цепочку

Паттерн Chain of Responsibility решает проблемы:
- Избегает жёсткой привязки отправителя запроса к получателю
- Позволяет гибко настраивать порядок обработки
- Даёт возможность динамически изменять цепочку обработчиков

Метафоры из реального мира:
- Техподдержка: Запрос передаётся от оператора к менеджеру, затем к директору
- Медицинский диагноз: Анализы проходят через несколько специалистов

Потенциальные проблемы:
- Запрос может остаться необработанным, если не добавить обработчик по умолчанию.
- Сложности с настройкой порядка выполнения запроса.
- При большом объеме инфоормации и большом кол-ве обработчиков процесс может затянуться.
