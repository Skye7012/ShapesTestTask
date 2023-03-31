# ShapesTestTask

### 1 Задание

- [Фигуры](src/Shapes/Shapes)
- [Юнит тесты](tests/Shapes.UnitTests)
- [Класс для создания фигур в runtime](src/Shapes/ShapeCreator.cs)

<br>
<br>

### 2 Задание
[SecondTaskQuery.sql — полный скрипт](SecondTaskQuery.sql)

Краткий inline ответ:
```sql
SELECT p.name, c.name FROM Product p 
LEFT JOIN Product_Category pc ON pc.product_id = p.id 
LEFT JOIN Category c ON pc.category_id = c.id 
```

<br>

![image](https://user-images.githubusercontent.com/86796337/229042619-9ba70803-a26b-4fdb-9319-99ca7cc36ce3.png)
