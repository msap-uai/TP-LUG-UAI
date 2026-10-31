# **Documentación del Proyecto** {#documentación-del-proyecto}

**Materia:** Lenguajes de Última Generación (LUG)  
**Institución:** Universidad Abierta Interamericana (UAI)  
**Proyecto:** Sistema de Gestión Integral para Policonsultorio Médico (POLICONSULTORIOS UAI)  
**Integrantes:**

- Gladys Milagros Sanchez Laime  
- Manuel Saponaro  
- Esteban Mariano Rogel Chaler

ÍNDICE

[Documentación del Proyecto](#documentación-del-proyecto)

[1\. Descripción Detallada del Sistema](#1.-descripción-detallada-del-sistema)

[1.1 Introducción y Propósito](#1.1-introducción-y-propósito)

[1.2 Alcance Funcional](#1.2-alcance)

[1.3 Arquitectura en Capas](#1.3-arquitectura-en-capas)

[2\. Diagrama de Base de Datos (DER)](#2.-diagrama-de-base-de-datos-\(der\))

[2.1 Diagrama Entidad-Relación (Mermaid)](#heading=h.l3slxl33mvwf)

[2.2 Diccionario de Datos](#2.2-diccionario-de-datos)

[3\. Diagrama de Clases (UML) con Herencia y Polimorfismo](#3.-diagrama-de-clases-\(uml\)-con-herencia-y-polimorfismo)

[3.1 Diagrama de Clases (Mermaid)](#3.1-diagrama-de-clases)

[3.2 Justificación de Herencia y Polimorfismo](#3.2-justificación-de-herencia-y-polimorfismo)

[4\. Manual de Usuario](#4.-manual-de-usuario)

[4.1 Ventana Principal (Contenedor MDI)](#4.1-ventana-principal-\(contenedor-mdi\))

[4.2 Módulo de Obras Sociales](#4.2-módulo-de-obras-sociales)

[4.3 Módulo de Especialidades Médicas](#4.3-módulo-de-especialidades-médicas)

[4.4 Módulo de Pacientes](#4.4-módulo-de-pacientes)

[4.5 Módulo de Profesionales Médicos](#4.5-módulo-de-profesionales-médicos)

[4.6 Módulo de Turnos (Agendamiento)](#4.6-módulo-de-turnos-\(agendamiento\))

[4.7 Módulo de Atención Médica y Consulta/Evolución](#4.7-módulo-de-atención-médica-y-consulta/evolución)

## **1\. Descripción Detallada del Sistema** {#1.-descripción-detallada-del-sistema}

### **1.1 Introducción y Propósito** {#1.1-introducción-y-propósito}

El **Sistema de Gestión para Policonsultorios UAI** es un programa diseñado para informatizar y optimizar los procesos administrativos y médicos dentro de un centro de salud de atención ambulatoria. El sistema abarca desde la administración de pacientes, obras sociales y profesionales de distintas especialidades médicas, hasta la gestión de consultorios, la asignación de turnos, el registro de la historia clínica y el cobro arancelario.

### **1.2 Alcance** {#1.2-alcance}

El sistema contempla los siguientes módulos y procesos de negocio:

1. **Administración de Entidades:**  
   - Gestión (CRUD) de **Obras Sociales**.  
   - Gestión (CRUD) de **Especialidades Médicas** (Clínica Médica, Pediatría, Cardiología, Traumatología, etc.).  
   - Administración de **Consultorios** disponibles en el policonsultorio.  
2. **Gestión de Personas (Herencia):**  
   - **Pacientes:** Registro de datos personales, fecha de nacimiento, cobertura médica (obra social) y número de credencial/afiliado.  
   - **Profesionales Médicos:** Registro de datos personales, matrícula habilitante, especialidad médica y valor de la consulta.  
3. **Gestión de Turnos:**  
   - Reserva de turnos asociando un Paciente con un Profesional, en un Consultorio para una fecha y hora específica.  
   - **Reglas de Negocio:** Validación que previene la superposición horaria para un mismo profesional o en un mismo consultorio físico.  
   - Control de ciclo del turno (Pendiente, Atendido, Cancelado).  
4. **Atención Médica y Consulta (Manejo Transaccional):**  
   - Registro de la evolución médica del paciente.  
   - **Transaccionalidad:** El registro de la evolución médica, el impacto del cobro y la actualización del estado del turno a Atendido se ejecutan bajo una misma transacción (SqlTransaction), garantizando la consistencia total de la base de datos.

### **1.3 Arquitectura en Capas** {#1.3-arquitectura-en-capas}

La aplicación está implementada bajo una **Arquitectura en Capas** desacoplando responsabilidades:

- **UI (Capa de Presentación \- WinForms MDI):** Interfaz gráfica de usuario basada en un formulario contenedor MDI .  
- **BLL (Capa de Lógica de Negocio):** Centraliza las reglas de negocio, validaciones de formato, lógica de negocio relacional y control de transacciones.  
- **DAL (Capa de Acceso a Datos):** Encargada de la persistencia y ejecución de sentencias SQL hacia la base de datos SQL Server mediante Microsoft.Data.SqlClient y transacciones (SqlTransaction).  
- **MPP (Capa de Mapeo de Objetos):** Convierte registros de SqlDataReader  en instancias ricas del modelo de objetos (BE), aislando la representación relacional de la orientada a objetos.  
- **BE (Entidades de Negocio):** Biblioteca con las clases que representan el modelo del dominio (Persona, Paciente, Profesional, Turno, etc.), encapsulando atributos, propiedades con validaciones intrínsecas y métodos polimórficos.

---

## **2\. Diagrama de Base de Datos (DER)** {#2.-diagrama-de-base-de-datos-(der)}

El diseño de la base de datos relacional para Microsoft SQL Server 

### **2.1 Diagrama Entidad-Relación** 

### **2.2 Diccionario de Datos** {#2.2-diccionario-de-datos}

| Tabla | Campo | Tipo de Dato | Acepta nulos | Restricción / Clave | Descripción |
| :---- | :---- | :---- | :---- | :---- | :---- |
| **PERSONA** | ID\_PERSONA | INT | NOT NULL | **PK**   | Identificador único de la persona física. |
|  | NOMBRE | VARCHAR(50) | NOT NULL |  | Nombre de la persona. |
|  | APELLIDO | VARCHAR(50) | NOT NULL |  | Apellido de la persona. |
|  | DNI | VARCHAR(10) | NOT NULL | **UNIQUE** | Documento nacional de identidad (único). |
|  | TELEFONO | VARCHAR(20) | NULL |  | Teléfono de contacto. |
|  | MAIL | VARCHAR(100) | NULL |  | Correo electrónico de contacto. |
| **PACIENTE** | ID\_PACIENTE | INT | NOT NULL | **PK**   | Identificador único de paciente. |
|  | ID\_PERSONA | INT | NOT NULL | **FK**  | Relación de herencia/tabla padre. |
|  | FECHA\_NACIMIENTO | DATE | NOT NULL |  | Fecha de nacimiento. |
|  | ID\_OBRA\_SOCIAL | INT | NULL | **FK**  | Cobertura médica asociada (opcional/particular). |
|  | NUMERO\_AFILIADO | VARCHAR(30) | NULL |  | Número de credencial de obra social. |
| **PROFESIONAL** | ID\_PROFESIONAL | INT | NOT NULL | **PK**  | Identificador único del médico/profesional. |
|  | ID\_PERSONA | INT | NOT NULL | **FK**  | Relación con datos personales. |
|  | MATRICULA | VARCHAR(20) | NOT NULL | **UNIQUE** | Matrícula profesional habilitante. |
|  | ID\_ESPECIALIDAD | INT | NOT NULL | **FK**  | Especialidad principal del médico. |
|  | ARANCEL | DECIMAL(10,2) | NOT NULL |  | Arancel base por consulta. |
| **OBRA\_SOCIAL** | ID\_OBRA\_SOCIAL | INT | NOT NULL | **PK**   | Identificador único de la entidad aseguradora. |
|  | NOMBRE | VARCHAR(100) | NOT NULL | **UNIQUE** | Denominación legal de la obra social. |
| **ESPECIALIDAD** | ID\_ESPECIALIDAD | INT | NOT NULL | **PK**   | Identificador único de la especialidad. |
|  | DESCRIPCION | VARCHAR(60) | NOT NULL | **UNIQUE** | Nombre de la especialidad médica. |
| **CONSULTORIO** | ID\_CONSULTORIO | INT | NOT NULL | **PK**   | Identificador único del espacio físico. |
|  | NUMERO\_CONSULTORIO | INT | NOT NULL | **UNIQUE** | Número asignado al consultorio (1 al 9). |
| **TURNO** | ID\_TURNO | INT | NOT NULL | **PK**   | Identificador único del turno. |
|  | ID\_PACIENTE | INT | NOT NULL | **FK**  | Paciente que solicitó el turno. |
|  | ID\_PROFESIONAL | INT | NOT NULL | **FK**  | Profesional que brindará la atención. |
|  | ID\_CONSULTORIO | INT | NOT NULL | **FK**  | Consultorio reservado para la atención. |
|  | FECHA\_HORA | DATETIME | NOT NULL |  | Fecha y hora pactada para el turno. |
|  | ESTADO | VARCHAR(20) | NOT NULL |  | Estado actual (Pendiente, Atendido, Cancelado). |
| **CONSULTA\_EVOLUCION** | ID\_CONSULTA | INT | NOT NULL | **PK**   | Identificador único del registro médico. |
|  | ID\_TURNO | INT | NOT NULL | **FK**  | Turno que originó la atención. |
|  | FECHA\_ATENCION | DATETIME | NOT NULL |  | Momento exacto de la atención médica. |
|  | OBSERVACIONES | VARCHAR(MAX) | NULL |  | Notas de evolución del paciente. |
|  | DIAGNOSTICO | VARCHAR(500) | NULL |  | Diagnóstico emitido por el profesional. |
|  | MEDICACION | VARCHAR(500) | NULL |  | Indicaciones farmacológicas recetadas. |
|  | MONTO\_COBRADO | DECIMAL(10,2) | NOT NULL |  | Monto monetario percibido en la consulta. |

---

## 

## 

## 

## **3\. Diagrama de Clases (UML) con Herencia y Polimorfismo** {#3.-diagrama-de-clases-(uml)-con-herencia-y-polimorfismo}

El modelo de clases implementa los principios fundamentales del paradigma orientado a objetos (POO): **Abstracción, Encapsulamiento, Herencia y Polimorfismo**.

### **3.1 Diagrama de Clases**  {#3.1-diagrama-de-clases}

### 

### 

### 

### 

### **3.2 Justificación de Herencia y Polimorfismo** {#3.2-justificación-de-herencia-y-polimorfismo}

1. **Herencia:**

   - Paciente y Profesional heredan directamente de Persona, reutilizando todo el encapsulamiento y agregando únicamente la especialización correspondiente a su rol en el negocio (obra social, matrícula, arancel, etc.).

   

2. **Polimorfismo:**  
     
   - **ObtenerIdentificacionCompleta()**: Método virtual en Persona sobrescrito (override) en las clases derivadas:  
     - En Paciente: Retorna Apellido, Nombre (DNI: XXXXXXXX) \- OS: \[Nombre OS / Particular\] \- Afiliado N° \[Nro\].  
     - En Profesional: Retorna Dr./Dra. Apellido, Nombre (MN/MP: \[Matricula\]) \- Esp: \[Especialidad\].  
   - **CalcularCostoFinal(decimal arancelBase)**:  
     - En Paciente: Aplica la lógica de cobertura: si el paciente posee Obra Social aplica el porcentaje de cobertura acordado (copago bonificado); si es Particular retorna el arancel completo.  
     - En Profesional: Retorna el valor liquidable correspondiente a los honorarios fijados.  
   - **Polimorfismo en la Interfaz Gráfica (MiForm):**  
     - La clase base de formularios [MiForm.cs](file:///d:/UAI/LUG%20C%23/TP%20LUG/TP%20LUG/WinFormsApp1/MiForm.cs) expone métodos virtuales (HayCambios(), ConfirmarCambios(), ModoNuevoRegistro()) que son sobreescritos por cada formulario CRUD secundario (como [Especialidad.cs](file:///d:/UAI/LUG%20C%23/TP%20LUG/TP%20LUG/WinFormsApp1/Especialidad.cs) y [ObraSocial.cs](file:///d:/UAI/LUG%20C%23/TP%20LUG/TP%20LUG/WinFormsApp1/ObraSocial.cs)), asegurando un comportamiento estándar ante salidas sin guardar y limpiezas de pantalla.

---

## **4\. Manual de Usuario** {#4.-manual-de-usuario}

Este manual orienta al usuario operador y administrativo en la utilización de las diferentes funcionalidades del sistema **POLICONSULTORIOS UAI**.

### **4.1 Ventana Principal (Contenedor MDI)** {#4.1-ventana-principal-(contenedor-mdi)}

Al iniciar la aplicación se presenta la pantalla principal contenedora (Inicio). Desde la barra superior de menú (MenuStrip) se accede a las diferentes áreas organizadas por módulos:

- **Archivo:** Obras Sociales, Especialidades Médicas, Consultorios.  
- **Gestión Médica:** Administración de Pacientes y Profesionales.  
- **Turnos:** Asignación, reprogramación y consulta de agenda de turnos.  
- **Atención Médica:** Registro de evolución clínica y cobro de consultas.

---

### **4.2 Módulo de Obras Sociales** {#4.2-módulo-de-obras-sociales}

#### **Acceso**

En la barra de menú, seleccionar **Archivo \> Obras Sociales** (o presionar el botón de acceso rápido correspondiente).

#### **Operaciones**

1. **Alta de Obra Social:**  
   - Al abrir el formulario, el sistema se posiciona automáticamente en *Modo Nuevo Registro*.  
   - Ingresar el nombre de la obra social en el campo de texto (mínimo 3 caracteres, máximo 100 caracteres).  
   - Presionar el botón **Guardar**. El sistema validará la información, persistirá el registro y actualizará la grilla inferior.  
2. **Modificación:**  
   - Hacer clic sobre la fila de la obra social a modificar en la grilla (DataGridView).  
   - El nombre se cargará en el cuadro de texto superior y el botón cambiará su contexto a modo edición.  
   - Modificar el texto y presionar **Guardar**.  
3. **Baja / Eliminación:**  
   - Seleccionar la obra social desde la grilla.  
   - Presionar el botón **Eliminar**.  
   - El sistema solicitará confirmación. **Regla de negocio:** Si la obra social tiene pacientes afiliados asociados, el sistema bloqueará la eliminación y emitirá un mensaje de advertencia explicando el motivo.  
4. **Control de Cambios:**  
   - Si se han realizado modificaciones en el cuadro de texto y se intenta seleccionar otra fila o cerrar la ventana sin guardar, el sistema desplegará un cuadro de diálogo advirtiendo que existen cambios sin guardar para evitar la pérdida accidental de datos.

---

### **4.3 Módulo de Especialidades Médicas** {#4.3-módulo-de-especialidades-médicas}

#### **Acceso**

En la barra de menú, seleccionar **Archivo \> Especialidades Médicas**.

#### **Operaciones**

1. **Alta de Especialidad:**  
   - Ingresar la descripción de la especialidad (ej. *Cardiología*, *Dermatología*, *Pediatría*) respetando entre 3 y 60 caracteres.  
   - Presionar **Guardar**.  
2. **Modificación:**  
   - Seleccionar el registro de la grilla, editar la descripción y presionar **Guardar**.  
3. **Eliminación:**  
   - Seleccionar la especialidad y hacer clic en **Eliminar**.  
   - **Regla de negocio:** Si existen médicos registrados con dicha especialidad, la eliminación será denegada por la BLL para preservar la integridad del policonsultorio.

---

### **4.4 Módulo de Pacientes** {#4.4-módulo-de-pacientes}

#### **Acceso**

En la barra de menú, seleccionar **Gestión Médica \> Pacientes**.

#### **Operaciones**

1. **Registro de Paciente:**  
   - Completar los datos personales: **Nombre**, **Apellido**, **DNI** (solo números, validación de unicidad), **Teléfono** y **Correo Electrónico**.  
   - Ingresar la **Fecha de Nacimiento** (debe ser menor o igual a la fecha actual).  
   - Seleccionar del desplegable la **Obra Social** correspondiente (o seleccionar *Particular* si no cuenta con cobertura).  
   - Si posee obra social, ingresar el **Número de Afiliado**.  
   - Presionar **Guardar**. El sistema realiza una transacción en dos etapas (PERSONA y PACIENTE) garantizando que ambas tablas queden sincronizadas.  
2. **Búsqueda y Filtro:**  
   - Posibilidad de buscar pacientes por DNI o filtrar por Obra Social para consultar la nómina de afiliados.

---

### **4.5 Módulo de Profesionales Médicos** {#4.5-módulo-de-profesionales-médicos}

#### **Acceso**

En la barra de menú, seleccionar **Gestión Médica \> Profesionales**.

#### **Operaciones**

1. **Alta de Profesional:**  
   - Completar datos personales (Nombre, Apellido, DNI, Contacto).  
   - Ingresar la **Matrícula** profesional (única).  
   - Seleccionar la **Especialidad Médica** del menú desplegable.  
   - Definir el valor de **Arancel** de consulta (número positivo mayor a cero).  
   - Presionar **Guardar**.  
2. **Actualización de Aranceles:**  
   - Permite seleccionar un médico para reajustar su valor de consulta periódicamente.

---

### **4.6 Módulo de Turnos (Agendamiento)** {#4.6-módulo-de-turnos-(agendamiento)}

#### **Acceso**

En la barra de menú, seleccionar **Turnos \> Asignación de Turnos**.

#### **Operaciones**

1. **Otorgar Turno:**  
   - Seleccionar el **Paciente** solicitante.  
   - Seleccionar el **Profesional** médico deseado.  
   - Indicar la **Fecha y Hora** del turno mediante el selector de calendario/hora.  
   - Asignar el **Consultorio** físico (1 al 9).  
   - Presionar **Asignar Turno**.  
   - **Validación de Regla de Negocio:**  
     - El sistema verifica en tiempo real que el profesional no tenga otro turno en el mismo rango horario.  
     - El sistema verifica que el consultorio no esté ocupado por otro médico en ese mismo horario.  
     - En caso de superposición, se cancela la operación y se muestra una advertencia con el conflicto detectado.  
2. **Cancelación o Reprogramación:**  
   - Permite cambiar el estado de un turno a Cancelado o reasignar su fecha y consultorio.

---

### **4.7 Módulo de Atención Médica y Consulta/Evolución** {#4.7-módulo-de-atención-médica-y-consulta/evolución}

#### **Acceso**

En la barra de menú, seleccionar **Atención Médica \> Consulta y Evolución**.

#### **Operaciones**

1. **Atención del Turno:**  
   - El profesional médico visualiza la grilla de turnos Pendientes asignados para la fecha.  
   - Al hacer doble clic en el turno del paciente a atender, se habilita el panel clínico.  
2. **Carga de Datos Clínicos:**  
   - **Diagnóstico:** Conclusión médica de la consulta (hasta 500 caracteres).  
   - **Medicación:** Fármacos o indicaciones prescriptas (hasta 500 caracteres).  
   - **Observaciones:** Notas clínicas generales de evolución.  
   - **Monto Cobrado:** Importe percibido por la consulta (calculado según el arancel del profesional y la cobertura del paciente).  
3. **Cierre de Consulta (Transaccional):**  
   - Presionar **Finalizar Consulta**.  
   - En una **única transacción (SqlTransaction)**:  
     1. Se inserta el registro en la tabla CONSULTA\_EVOLUCION.  
     2. Se actualiza el estado del TURNO a Atendido.  
     3. Se registra el cobro.  
   - Si cualquier paso falla, la base de datos realiza un Rollback, evitando que queden turnos atendidos sin historia clínica o historias clínicas sin turno asociado.