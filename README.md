# Carfleet - Evaluation UML1 - 2023-2024

## Cahier des charges

Etudier le diagramme de séquence livré ci-dessous et tenez compte des informations supplémentaires suivantes afin de réaliser le code et le diagramme de classes :

### Spécifications
---
La classe Driver:

* Hérite de la classe Person.
* La méthode "detectMinorDamages" produit toujours le même résultat: elle retourne le type string[] (sans contenu métier).

---
La classe Person:

* Est identifiée grâce à une adresse email.

---
La classe Vehicle:

* Est identifiée grâce à son numéro de chassis.
* Les méthodes start/stop engine n'ont aucun impact sur la classe (c'est toujours un succès).

---
La classe DamageReport:

* Nécessite de recevoir la liste des dommages détectés ainsi que le véhicule concerné pour être instanciée.

--
Exceptions

* La hérarchie des exceptions n'est pas imposée. Trouvez une solution "élégante".

### Diagramme de séquence

![SequenceDiagram](./img/SequenceDiagramSpecs.JPG)