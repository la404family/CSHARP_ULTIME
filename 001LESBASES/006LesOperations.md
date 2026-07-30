# Les opérateurs en C-Sharp

Les opérateurs sont des symboles qui effectuent des opérations sur des variables et des valeurs. Ils permettent de manipuler des données, de comparer des valeurs et de contrôler le flux d'exécution d'un programme.

## Sommaire

1. [Opérateurs arithmétiques](#les-opérateurs-arithmétiques)
2. [Opérateurs de comparaison](#les-opérateurs-de-comparaison)
3. [Opérateurs logiques](#les-opérateurs-logiques)
4. [Opérateurs d'affectation](#les-opérateurs-daffectation)
5. [Opérateurs d'incrémentation/décrémentation](#les-opérateurs-dincrémentation-et-décrémentation)
6. [Opérateurs de bits](#les-opérateurs-de-bits)
7. [Opérateurs divers](#opérateurs-divers)

## Les opérateurs arithmétiques

Utilisés pour les calculs mathématiques de base :

| Opérateur | Description          | Exemple    | Résultat   |
| --------- | -------------------- | ---------- | ---------- |
| `+`       | Addition             | `5 + 3`    | 8          |
| `-`       | Soustraction         | `5 - 3`    | 2          |
| `*`       | Multiplication       | `5 * 3`    | 15         |
| `/`       | Division             | `10 / 3`   | 3 (entier) |
| `%`       | Modulo (reste)       | `10 % 3`   | 1          |
| `/`       | Division (flottante) | `10.0 / 3` | 3.333...   |

```csharp
int a = 10, b = 3;
Console.WriteLine(a + b);  // 13
Console.WriteLine(a / b);  // 3 (division entière)
Console.WriteLine((double)a / b);  // 3.333... (division flottante)
```

## Les opérateurs de comparaison

Utilisés pour comparer des valeurs et retourner un booléen (`true` ou `false`) :

| Opérateur | Description         | Exemple  | Résultat |
| --------- | ------------------- | -------- | -------- |
| `==`      | Égal à              | `5 == 5` | true     |
| `!=`      | Différent de        | `5 != 3` | true     |
| `>`       | Supérieur à         | `5 > 3`  | true     |
| `<`       | Inférieur à         | `5 < 3`  | false    |
| `>=`      | Supérieur ou égal à | `5 >= 5` | true     |
| `<=`      | Inférieur ou égal à | `5 <= 3` | false    |

```csharp
int a = 5, b = 3;
Console.WriteLine(a == b);  // false
Console.WriteLine(a != b);  // true
Console.WriteLine(a > b);   // true
Console.WriteLine(a < b);   // false
Console.WriteLine(a >= b);  // true
Console.WriteLine(a <= b);  // false
```

## Les opérateurs logiques

Utilisés pour combiner des expressions booléennes :

| Opérateur | Description | Exemple         | Résultat |
| --------- | ----------- | --------------- | -------- |
| `&&`      | ET logique  | `true && false` | false    |
| "\|\|"    | OU logique  | `true or false` | true     |
| `!`       | NON logique | `!true`         | false    |

```csharp
bool a = true, b = false;
Console.WriteLine(a && b);  // false
Console.WriteLine(a || b);  // true
Console.WriteLine(!a);     // false
```

## Les opérateurs d'affectation

Utilisés pour assigner des valeurs à des variables :

| Opérateur | Description                      | Exemple   | Résultat   |
| --------- | -------------------------------- | --------- | ---------- |
| `=`       | Affectation simple               | `a = 5`   | a = 5      |
| `+=`      | Addition et affectation          | `a += 3`  | a = a + 3  |
| `-=`      | Soustraction et affectation      | `a -= 3`  | a = a - 3  |
| `*=`      | Multiplication et affectation    | `a *= 3`  | a = a \* 3 |
| `/=`      | Division et affectation          | `a /= 3`  | a = a / 3  |
| `%=`      | Modulo et affectation            | `a %= 3`  | a = a % 3  |
| `&=`      | ET bit à bit et affectation      | `a &= 3`  | a = a & 3  |
| `\|=`     | OU bit à bit et affectation      | `a \|= 3` | a = a \| 3 |
| `^=`      | OU exclusif et affectation       | `a ^= 3`  | a = a ^ 3  |
| `<<=`     | Décalage à gauche et affectation | `a <<= 3` | a = a << 3 |
| `>>=`     | Décalage à droite et affectation | `a >>= 3` | a = a >> 3 |

|

```csharp
int a = 5;
a += 3;  // a = a + 3
Console.WriteLine(a);  // 8
a -= 2;  // a = a - 2
Console.WriteLine(a);  // 6
a *= 2;  // a = a * 2
Console.WriteLine(a);  // 12
a /= 3;  // a = a / 3
Console.WriteLine(a);  // 4
a %= 2;  // a = a % 2
Console.WriteLine(a);  // 0
```

## Les opérateurs d'incrémentation et décrémentation

Utilisés pour augmenter ou diminuer la valeur d'une variable de 1 :

| Opérateur | Description             | Exemple | Résultat |
| --------- | ----------------------- | ------- | -------- |
| `++`      | Incrémentation          | `a++`   | a + 1    |
| `--`      | Décrémentation          | `a--`   | a - 1    |
| `++a`     | Incrémentation préfixée | `++a`   | a + 1    |
| `--a`     | Décrémentation préfixée | `--a`   | a - 1    |

```csharp
int a = 5;
Console.WriteLine(a++);  // 5 (post-incrémentation)
Console.WriteLine(a);    // 6
Console.WriteLine(++a);  // 7 (pré-incrémentation)
Console.WriteLine(a--);  // 7 (post-décrémentation)
Console.WriteLine(a);    // 6
Console.WriteLine(--a);  // 5 (pré-décrémentation)
```

## Les opérateurs de bits

Utilisés pour effectuer des opérations sur les bits d'un entier :

| Opérateur | Description           | Exemple  | Résultat |
| --------- | --------------------- | -------- | -------- |
| `&`       | ET bit à bit          | `a & b`  | a & b    |
| `\|`      | OU bit à bit          | `a \| b` | a \| b   |
| `^`       | OU exclusif bit à bit | `a ^ b`  | a ^ b    |
| `~`       | NON bit à bit         | `~a`     | ~a       |
| `<<`      | Décalage à gauche     | `a << 1` | a << 1   |
| `>>`      | Décalage à droite     | `a >> 1` | a >> 1   |

```csharp
int a = 5;  // 0101 en binaire
int b = 3;  // 0011 en binaire
Console.WriteLine(a & b);  // 1 (0001 en binaire)
Console.WriteLine(a | b);  // 7 (0111 en binaire)
Console.WriteLine(a ^ b);  // 6 (0110 en binaire)
Console.WriteLine(~a);     // -6 (complément à 1 de 0101)
Console.WriteLine(a << 1); // 10 (1010 en binaire)
Console.WriteLine(a >> 1); // 2 (0010 en binaire)
```

## Opérateurs divers

Utilisés pour des opérations spécifiques :

| Opérateur | Description              | Exemple         | Résultat      |
| --------- | ------------------------ | --------------- | ------------- |
| `?:`      | Opérateur ternaire       | `a > b ? a : b` | a > b ? a : b |
| `??`      | Opérateur de coalescence | `a ?? b`        | a ?? b        |

| `is` | Vérifie le type d'une variable | `a is int` | true si a est un int |
| `as` | Conversion de type | `a as string` | Convertit a en string, ou null si échec |

```csharp
int a = 5, b = 3;
Console.WriteLine(a > b ? a : b);  // 5 (opérateur ternaire)
Console.WriteLine(a ?? b);         // 5 (coalescence)
Console.WriteLine(a is int);      // true (vérifie le type)
Console.WriteLine(a as string);   // null (conversion de type)
```
