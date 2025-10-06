ÍNDICE
Control de Cambios ..... 2

1. Objeto ..... 7
2. Ámbito de aplicación ..... 7
3. Definiciones ..... 7
4. Documentos Tributarios Electrónicos ..... 9
5. Estructura de Datos y Formato Electrónico ..... 9
5.1 Especificaciones tecnológicas y con fines de control ..... 10
6. Emisión ..... 10
6.1 Emisión con Transmisión Previa a la Administración Tributaria ..... 10
6.2 Emisión con Transmisión Diferida a la Administración Tributaria ..... 10
7. Generación ..... 11
7.1 Código de Generación ..... 11
7.2 Número de Control ..... 11
7.3 Regla de Redondeos ..... 11
a) Redondeos por Ítem: ..... 11
b) Redondeos en Sección Resumen: ..... 11
7.4 Regla de Holgura: ..... 12
8. Firma electrónica ..... 12
9. Transmisión ..... 13
9.1. Plataformas de Transmisión ..... 14
10. Reglas para el otorgamiento del Sello de Recepción ..... 14
10.1. Estados de los documentos ..... 15
10.2. Registro y declaración de los DTE ..... 16
11. Entrega de los DTE ..... 16
11.1 Entrega con Transmisión Previa ..... 16
11.2 Entrega con Transmisión Diferida ..... 17
11.3 Versiones interpretadas y legibles del Documento Tributario Electrónico ..... 17
12. Conservación de los DTE ..... 18
12.1 Anulación y destrucción de documentos físicos ..... 18
13. Eventos ..... 18
13.1 Transmisión de los Eventos ..... 19
13.1.1 Evento de Invalidación ..... 19
13.1.2 Evento de Contingencia ..... 19
13.2 Lineamientos para el evento de invalidación ..... 20
13.2.1 Reglas para invalidación de Facturas y Facturas de Exportación Electrónicas ..... 20
13.2.2 Diferencia entre error y afectación ..... 20
13.3 Efectos del Evento de Invalidación ..... 21
13.4 Efectos del Evento de Contingencia. ..... 21
14. Consulta ..... 22
15. Coexistencia ..... 22
16. Gratuidad ..... 23
17. Programa de Implementación. ..... 23
18. Fechas y condiciones para liberación de la presentación de informes ..... 23
19. Lineamientos para Versiones y Modificaciones de la Normativa ..... 24
20. Anexos ..... 24
21. Vigencia ..... 24
ANEXO I ..... 25
ESPECIFICACIONES TECNOLÓGICAS ..... 25
22. GENERACIÓN DE LOS DTE. ..... 25
1.1. Código de Generación ..... 25
1.2. Campos y Secciones ..... 25
1.3. Definición de condiciones de campo ..... 27
1.3.1. Restricciones de uso en los campos de los DTE ..... 27
1.4. Estructura de Datos ..... 28
1.5. Formato Electrónico ..... 28
1.6. Reglas para el otorgamiento del Sello de Recepción de los DTE y Eventos ..... 30
1.7. Catálogos ..... 31
23. FIRMA ELECTRÓNICA ..... 31
2.1. Condiciones y mecanismos ..... 31
24. TRANSMISIÓN ..... 33
3.1. Ambientes de Transmisión ..... 33
3.2. Servicio de Transmisión para Eventos de Invalidación y Contingencia ..... 33
3.3. Autenticación ..... 33
3.4. Recepción de los DTE ..... 33
3.5. Sello de Recepción ..... 34
25. ENTREGA ..... 34
26. MÓDULOS ..... 34
27. SEGURIDAD ..... 35
28. FLUJO DE PROCESO DTE ..... 36
ANEXO II ..... 37
ESTRUCTURA DE DATOS DTE ..... 37
ANEXO III ..... 78
ESTRUCTURA DE DATOS EVENTOS ..... 78
ANEXO IV ..... 84
VALIDACIONES PARA CAMPOS DTE ..... 84
ANEXO V ..... 106
VALIDACIONES PARA CAMPOS EVENTOS ..... 106

La Dirección General de Impuestos Internos, con base a lo establecido en los articulos 1 y 3 de la Ley Orgánica de la Dirección General de Impuestos Internos, 119-A inciso segundo del Código Tributario y 160 de la Ley de Procedimientos Administrativos; y.

CONSIDERANDO:
I. Que mediante Decreto Legislativo No. 230, de fecha 14 de diciembre de 2000, publicado en el Diario Oficial No. 241, Tomo 349, del 22 de ese mismo mes y año se emitió el Código Tributario, el cual ha sido objeto de reformas mediante los Decretos respectivos. Que dentro de esas reformas, se encuentra la contenida en el Decreto Legislativo No. 487, de fecha 30 de agosto de 2022, publicado en el Diario Oficial No. 197 Tomo 436, de fecha 20 de septiembre de 2022, en el cual se adicionó al Código Tributario la Subsección Primera, de la Sección Quinta del Capítulo I del Título III, sobre Documentos Tributarios Electrónicos.
II. Que, habiéndose aprobado las disposiciones legales especificas relativas al uso de los Documentos Tributarios Electrónicos, es necesario emitir las correspondientes normas administrativas, de acuerdo a lo establecido en el artículo 119-A inciso segundo del Código Tributario.
III. Que el artículo 119-A inciso segundo del Código Tributario, establece que la Administración Tributaria está facultada para emitir la normativa que garantice el adecuado cumplimiento de las obligaciones relativas a los documentos tributarios electrónicos. Asimismo, que dicha normativa será de estricto cumplimiento para los sujetos pasivos, pudiendo ejercerse las facultades sancionatorias ante su incumplimiento.
IV. Que la Administración Tributaria, dando cumplimiento al procedimiento descrito en el artículo 162 de la Ley de Procedimientos Administrativos, desde el mes de abril de dos mil veinte, ha atendido a diversos contribuyentes que voluntariamente presentaron solicitud para el reemplazo de la documentación física por el uso del sistema de emisión de Documentos Tributarios Electrónicos, con base al artículo 113 inciso primero del Código Tributario; a partir de lo cual se recibieron oportunamente las recomendaciones o sugerencias de parte de los contribuyentes involucrados en el Programa de Implementación de Facturación Electrónica, así como las recopiladas en los eventos de divulgación realizados con gremiales de profesionales, de comercio e industria, como las formuladas por el público en general mediante los canales oficiales de comunicación disponibles, las cuales han sido evaluadas y consideradas por la Administración Tributaria para el modelo operativo del sistema, como para el desarrollo de los contenidos de la presente Normativa.
V. Que los Documentos Tributarios Electrónicos facilitan los procesos tributarios a los sujetos pasivos, generan optimización de recursos, a través de la reducción de los costos de papelería, impresión, distribución y almacenaje de los documentos tradicionalmente emitidos en formato físico.

POR TANTO, se emite la siguiente:

NORMATIVA DE CUMPLIMIENTO DE LOS DOCUMENTOS TRIBUTARIOS ELECTRÓNICOS

1. Objeto

La presente Normativa tiene por objeto establecer las condiciones necesarias para la correcta generación, firma, transmisión, recepción y entrega de los Documentos Tributarios Electrónicos; así como sus especificaciones y demás procedimientos, que garanticen el adecuado cumplimiento de las obligaciones legales y de los Eventos relacionados a los mismos.
2. Ámbito de aplicación

Las disposiciones establecidas en la presente Normativa serán de estricto cumplimiento para los sujetos pasivos emisores de documentos tributarios electrónicos, de acuerdo a lo establecido en el artículo 119-A inciso segundo del Código Tributario.
3. Definiciones

Para los efectos de lo establecido en el Código Tributario y en la presente Normativa, se entenderá por:
a) Anexo: Documento emitido por la Administración Tributaria que forma parte integrante de esta Normativa y que contiene la descripción de las características, condiciones, mecanismos tecnológicos para la generación, firma, transmisión, recepción y entrega al receptor de los Documentos Tributarios Electrónicos y de los Eventos relacionados a los mismos, así como los demás mecanismos conforme al modelo operativo y a la plataforma informática dispuesta para tal efecto.
b) Archivo DTE: Es un archivo electrónico de extensión JSON que contiene: el texto plano del documento generado conforme a la Estructura de Datos contenida en el Anexo II de esta Normativa, además del DTE firmado conforme se establece en el "Manual Tecnológico para la Integración del Sistema de Transmisión", incorporando el Sello de Recepción otorgado por la Administración Tributaria.
c) Certificado de firma electrónica falso: Es el certificado que declara uno o más datos alterados o manipulados a partir de su creación, para efecto de lo establecido en el artículo 199 del Código Tributario.
d) Código de Generación: Es un número identificador único, aleatorio y universal, en formato UUID (Identificador Único Universal) versión 4, que servirá para la correcta identificación del documento transmitido y efectuar la consulta del mismo en el sitio web del Ministerio de Hacienda.
e) Sitio emisores DTE: Es el servicio dispuesto por la Administración Tributaria para que los emisores de DTE puedan realizar las gestiones operativas relacionadas con dichos documentos.
f) Contingencia: Se refiere a la situación imprevista ocasionada por caso fortuito o fuerza mayor que impida la transmisión previa de los documentos a la Administración Tributaria.
g) Documento Electrónico: Información de cualquier naturaleza, contenida en soporte electrónico, según un formato determinado. Para efectos de la presente Normativa, documento
electrónico contentivo de los grupos de información y datos, que se encuentra firmado electrónicamente a efecto de ser transmitido a la Administración Tributaria pero que no cuenta con el Sello de Recepción otorgado conforme a las reglas previstas para ello.
h) Documento Electrónico Apócrifo: Es el documento tributario generado, firmado y transmitido electrónicamente a la Administración Tributaria, con o sin Sello de Recepción otorgado por la misma, que lesiona el interés fiscal, conforme a lo establecido en el artículo 199 inciso tercero del Código Tributario y en la presente Normativa. Estos documentos son elaborados para soportar operaciones inexistentes, con el fin de reducir el pago de impuestos.
i) Documento Tributario Electrónico (DTE): Es el documento tributario generado con la Estructura de Datos, Formato Electrónico, firmado y transmitido electrónicamente conforme a lo establecido por la Administración Tributaria y que cuenta con el Sello de Recepción otorgado por la misma.
j) Emisor: Sujeto que expide Documentos Tributarios Electrónicos.
k) Estructuras de Datos: Conjunto de elementos o campos que integran el formato electrónico del documento.

1) Evento: Se refiere a un mensaje de datos firmado electrónicamente que contiene información relacionada con los Documentos Tributarios Electrónicos, que es transmitido a la Administración Tributaria y que cuenta con el Sello de Recepción otorgado por la misma.
m) Evento de Contingencia: Mensaje de datos firmado electrónicamente que se genera y transmite a la Administración Tributaria una vez cese la situación de fuerza mayor que imposibilitó la transmisión del documento electrónico a la Administración Tributaria.
n) Evento de Invalidación: Mensaje de datos firmado electrónicamente que se genera y transmite a la Administración Tributaria en ocasión de errores, ajustes o rescisiones en los Documentos Tributarios Electrónicos transmitidos, a efecto de la invalidación de los mismos.
o) Firma Electrónica: Son los datos en forma electrónica, consignados en un documento generado, que permiten la identificación del emisor del documento transmitido a la Administración Tributaria e indicar que el firmante aprueba la información recogida en el mensaje de datos o documento electrónico, para el otorgamiento del Sello de Recepción.
p) Formato Electrónico: Corresponde a la especificación que define la forma en que se organiza y se codifica la información de la Estructura de Datos de un documento electrónico generado, que en el caso de Documentos Tributarios Electrónicos se refiere al formato JSON.
q) Generación: Proceso mediante el cual la Estructura de Datos se incorpora en el Formato Electrónico JSON.
r) Holgura: Es la diferencia permitida en los campos numéricos de los DTE.
s) Plataforma Informática: Corresponde al servicio dispuesto por la Administración Tributaria, en el cual los emisores podrán transmitir los DTE y Eventos.
t) Receptor: Persona natural o Jurídica que recibe el Documento Tributario Electrónico, conforme a las reglas previstas en la presente Normativa.
u) Redondeo: Consiste en una regla fija para determinar en cada operación la última posición decimal dentro del rango, la cual se elevará cuando la primera posición decimal fuera de rango sea igual o mayor a 5.
v) Sello de Recepción: Consiste en un código especial otorgado por la Administración Tributaria que tiene como base un UUID Versión 4 y se le agregan caracteres alfanuméricos, que acredita la correcta transmisión y recepción de los documentos y Eventos generados y firmados, así como el carácter de Documento Tributario Electrónico que reúne los requisitos de idoneidad a que se refiere el artículo 206 inciso primero del Código Tributario.
w) Sitio web: Corresponde a la página digital de la Administración Tributaria que contiene información general, documentación del sistema y consultas de facturación electrónica.
x) Transmisión: Proceso de envío de un documento generado y firmado electrónicamente hacia la plataforma informática de la Administración Tributaria, con el objetivo de obtener el Sello de Recepción.
4. Documentos Tributarios Electrónicos

Conforme a lo dispuesto en los artículos 119-C y 119-G del Código Tributario, los Documentos Tributarios Electrónicos que serán emitidos por parte de los sujetos pasivos a que hace referencia el numeral 2 de la presente Normativa, son los siguientes:
a) Comprobante de Crédito Fiscal Electrónico (CCFE).
b) Factura Electrónica (FE).
c) Factura de Exportación Electrónica (FEXE).
d) Nota de Remisión Electrónica (NRE).
e) Nota de Crédito Electrónica (NCE)
f) Nota de Débito Electrónica (NDE).
g) Comprobante de Liquidación Electrónico (CLE).
h) Comprobante de Retención IVA Electrónico (CRE).
i) Documento Contable de Liquidación Electrónico (DCLE).
j) Factura de Sujeto Excluido Electrónica (FSEE).
k) Comprobante de Donación Electrónico (CDE).

Los Documentos Tributarios Electrónicos deben identificarse con el Código de Generación.
5. Estructura de Datos y Formato Electrónico

La Estructura de Datos para la emisión de los citados documentos deberá efectuarse conforme a las especificaciones establecidas en el artículo 119-G del Código Tributario y conforme a lo establecido en el Anexo II: "ESTRUCTURA DE DATOS DTE" de la presente Normativa.

El Formato Electrónico para la emisión de los Documentos Tributarios Electrónicos se encuentra descrito en el Anexo I: "ESPECIFICACIONES TECNOLÓGICAS" de esta Normativa.
Cuando deban actualizarse las Estructuras de Datos y Formato Electrónico de los documentos, dicha actualización será oportunamente comunicada y deberá cumplirse a efecto de mantener la integridad y seguridad del sistema de emisión de los DTE, conforme a los plazos establecidos en los Lineamientos para Versiones y Modificaciones de esta Normativa.
5.1 Especificaciones tecnológicas y con fines de control

Las especificaciones especiales a que se refiere el inciso segundo del artículo 119-G del Código Tributario, necesarias por razones tecnológicas o con fines de control, se encuentran establecidas e indicadas en la tabla de estructura de datos de dichos documentos, contenida en el Anexo II: "ESTRUCTURA DE DATOS DTE" de la presente Normativa.
6. Emisión

De conformidad a lo dispuesto en los artículos 119-A inciso primero literal a) y 119-C del Código Tributario, la emisión de Documentos Tributarios Electrónicos deberá cumplirse de la forma como se indica a continuación:
6.1 Emisión con Transmisión Previa a la Administración Tributaria

Conforme a lo dispuesto en el inciso primero del artículo 119-C del Código Tributario, como regla general, los sujetos pasivos deberán transmitir a la Administración Tributaria los archivos electrónicos de los documentos tributarios por cada operación que realicen para el otorgamiento del Sello de Recepción previamente a su entrega al receptor. Lo anterior aplica para transmisiones de DTE uno a uno o por lote.
6.2 Emisión con Transmisión Diferida a la Administración Tributaria

Excepcionalmente, de conformidad a lo dispuesto en el inciso tercero del artículo 119-C del Código Tributario, los contribuyentes estarán autorizados para transmitir en modalidad diferida en los casos y condiciones en que realicen operaciones en contingencia, conforme al siguiente orden: generación, firma electrónica, entrega al receptor conforme al punto 11.2 "Entrega con Transmisión Diferida" de esta Normativa, y superada la situación de fuerza mayor que dio lugar a la contingencia, deberá transmitirse el correspondiente Evento de Contingencia y posteriormente la transmisión de los documentos generados en contingencia a la Administración Tributaria para el otorgamiento diferido del Sello de Recepción, dentro del plazo establecido en el punto 2 del Cuadro 1: "Transmisión", de esta Normativa. Para este efecto, no se requiere resolución previa por parte de la Administración Tributaria.

En ambas modalidades, los citados documentos deberán entregarse a sus receptores con la misma estructura de datos y formato electrónico en que fueron generados y firmados.

Los sujetos pasivos deberán disponer de todos los medios adecuados y suficientes, tanto técnicos o administrativos, que aseguren el cumplimiento de la emisión de los DTE.
7. Generación

De conformidad a lo dispuesto en el artículo 119-A inciso primero literal b) del Código Tributario, se establece que la Generación de los Documentos Tributarios Electrónicos es un procedimiento que consiste en estructurar los datos que contendrán los documentos en formato electrónico.
7.1 Código de Generación

Durante el procedimiento de generación, deberá incorporarse al documento electrónico el Código de Generación, cuyo detalle técnico se encuentra en el punto 1.1 "Código de Generación" del Anexo I: "ESPECIFICACIONES TECNOLÓGICAS" de esta Normativa.
7.2 Número de Control

Durante el procedimiento de generación, deberá asignarse automáticamente el Número de Control, el cual consiste en un código alfanumérico compuesto por estas cuatro secciones:

- $1^{\circ}$ : deberá iniciar con las letras "DTE" que hace referencia a los Documentos Tributarios Electrónicos a emitir.
- $2^{\circ}$ : contendrá el Código de Tipo de Documento según el Catálogo CAT-002 establecido por la Administración Tributaria.
- $3^{\circ}$ : contendrá cuatro dígitos alfanuméricos que representan el código de Casa Matriz, Sucursal o Bodega, seguido de cuatro digitos alfanuméricos con el código de Punto de Venta.
- $4^{\circ}$ : contendrá un número consecutivo de quince dígitos de longitud, que iniciará en 1 y finalizará en 999999999999999.

Tendrá la siguiente estructura: DTE-00-00000000-000000000000000 y deberá reiniciar al inicio de cada ejercicio impositivo o cuando se agote dentro del mismo.
7.3 Regla de Redondeos

Los campos numéricos de los DTE deberán cumplir con las siguientes reglas de redondeo:
a) Redondeos por Item:

Se permitirá hasta ocho posiciones decimales (fraccionaria) en los campos numéricos de los DTE: cantidad, precio, descuento y total de ventas por ítem. En consecuencia, cuando la novena posición decimal de estos campos sea igual o mayor a 5 , la octava posición decimal se deberá redondear 1 hacia arriba.

Ejemplos: $1.123456784 \rightarrow 1.12345678$

$$
\begin{aligned}
& 1.123456785 \rightarrow 1.12345679 \\
& 1.123456786 \rightarrow 1.12345679
\end{aligned}
$$

b) Redondeos en Sección Resumen:

Se permitirá hasta dos posiciones decimales (fraccionaria) en los campos numéricos de la Sección Resumen de los DTE. En consecuencia, cuando la tercera posición decimal de estos campos sea igual o mayor a 5, la segunda posición decimal se deberá redondear 1 hacia arriba.

Ejemplos: $1.124 \rightarrow 1.12$
$1.125 \rightarrow 1.13$
$1.126 \rightarrow 1.13$
7.4 Regla de Holgura:

La diferencia permitida en los campos numéricos de los DTE será de una centésima, de esta forma:

| Valor | Redondeo | Holgura (-0.01) | Holgura (+0.01) |
| :---: | :---: | :---: | :---: |
| 1.124 | 1.12 | 1.11 | 1.13 |
| 1.125 | 1.13 | 1.12 | 1.14 |
| 1.126 | 1.13 | 1.12 | 1.14 |

En ese sentido, sin perjuicio de las posiciones decimales utilizadas por los sujetos pasivos en sus operaciones internas, éstos deberán cumplir con las anteriores reglas de redondeos y holgura en la generación de los DTE, ajustándose a ocho posiciones decimales los campos por ítem y a dos posiciones decimales los campos de la Sección Resumen, dentro de la holgura antes establecida.

Ejemplo Sección Cuerpo:
| Operación del sujeto pasivo Precio x cantidad | Valor por ítem (8 decimales) Precio x cantidad | Sumatoria de Venta (Máximo 8 decimales) |  |
| :--- | :--- | :--- | :--- |
|  |  | Holgura (-0.01) | Holgura (+0.01) |
| 1.1234567845678901 | 1.12345678 | 1.11345678 | 1.13345678 |
| 1.1267890167890123 | 1.12678902 | 1.11678902 | 1.13678902 |


Ejemplo Sección Resumen:
| Total de ventas gravadas (8 decimales) | Holgura de item | Valor resumen (2 decimales) | Sumatoria de Venta (Máximo 2 decimales) |  |
| :--- | :--- | :--- | :--- | :--- |
|  |  |  | Holgura (-0.01) | Holgura (+0.01) |
| 2.25024580 | (0.00) | 2.25 | 2.24 | 2.26 |
| 2.23024580 | (-0.01) | 2.23 | 2.22 | 2.24 |
| 2.27024580 | (+0.01) | 2.27 | 2.26 | 2.28 |


Es decir, que los campos de la Sección Resumen se deben calcular con base a los decimales de los campos por ítem del DTE y no con las posiciones decimales utilizadas por los sujetos pasivos en sus operaciones internas.

8. Firma electrónica

Con base a lo dispuesto en el artículo 119-C inciso cuarto del Código Tributario, los sujetos pasivos deberán firmar electrónicamente los Documentos Tributarios Electrónicos que emitan, conforme
a las condiciones y mecanismos de Firma Electrónica establecidos en el punto 2. FIRMA ELECTRÓNICA, del Anexo I: "ESPECIFICACIONES TECNOLÓGICAS" de la presente Normativa.

Para hacer uso de la firma electrónica, deberá obtenerse previamente el certificado emitido por la Administración Tributaria, el cual únicamente podrá utilizarse para emitir DTE.

La función de firma establecida se corresponde con el estándar JWS (JSON Web Signature), lo que garantiza la identificación del sujeto pasivo, la integridad del contenido e indica que el firmante aprueba la información contenida en el documento electrónico.

La Administración Tributaria podrá establecer la fecha a partir de la cual se permitirá el uso de certificados emitidos por un proveedor autorizado de servicios de certificación, a que se refiere el artículo 43 de la Ley de Firma Electrónica, a efecto de incorporar en los documentos que transmita la firma electrónica certificada correspondiente.

La firma electrónica otorga a los documentos el valor probatorio establecido en la Ley de Firma Electrónica; no obstante, son deducibles fiscalmente siempre y cuando cuenten con el Sello de Recepción correspondiente, de conformidad a lo establecido en los artículos 119-D inciso segundo y 206 del Código Tributario.

Asimismo, según lo dispuesto en el artículo 199 inciso primero del Código Tributario, los documentos electrónicos firmados no transmitidos a la Administración Tributaria presumen la generación de ingresos gravados por las transferencias de bienes o prestación de servicios.
9. Transmisión

De conformidad a lo dispuesto en el artículo 119-A inciso primero literal d) del Código Tributario, la Transmisión de los Documentos Electrónicos a la Administración Tributaria se realizará según la modalidad de emisión, en los siguientes plazos:

| No. | Modalidad de Emisión | Forma de Transmisión | Plazo | Entrega al Receptor | Tipo de Documento Electrónico |
| :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | Normal | Previa | Antes de su entrega al receptor. | Electrónica | Todos los descritos en el numeral 4 de la presente Normativa |
| 2 | Contingencia | Diferida | Hasta 72 horas contadas a partir del otorgamiento del Sello de Recepción del Evento de Contingencia. | Electrónica | Únicamente para CCFE, FE, FEXE, NRE, NDE y FSEE del numeral 4 de la presente Normativa. |

Cuadro 1: Transmisión
La forma y condiciones para la Transmisión de los Documentos Tributarios Electrónicos se encuentra establecida en el punto 3. TRANSMISIÓN del Anexo I: "ESPECIFICACIONES TECNOLÓGICAS" de la presente Normativa.
9.1. Plataformas de Transmisión

Las plataformas de transmisión de los DTE son:

- Sistema de Transmisión DTE: Su función es la transmisión de los datos de los DTE desde el sistema de emisión de documentos de cada sujeto pasivo al servicio de recepción de los DTE de la Administración Tributaria.

Los sujetos pasivos que utilicen este sistema deberán adecuar su sistema informático interno de acuerdo a los requerimientos técnicos funcionales específicos a su modelo de negocio, de forma que sean compatibles con los servicios de transmisión de documentos y Eventos a la Administración Tributaria, sin perjuicio de poder utilizar las tecnologías que mejor les resuelva dicha compatibilidad.

- Sistema de Facturación DTE: Su función es la transmisión de los datos de los DTE utilizando el sistema de facturación de la Administración Tributaria incorporado en la página web del Ministerio de Hacienda.

10. Reglas para el otorgamiento del Sello de Recepción

De conformidad a lo dispuesto en los artículos 119-A inciso primero literal f) y 119-C inciso quinto del Código Tributario, una vez se hayan generado, firmado y transmitido los Documentos Electrónicos y los Eventos respectivos, la Administración Tributaria verificará el cumplimiento de las siguientes reglas, previo al otorgamiento del Sello de Recepción:

1. Cumplir con los contenidos y especificaciones formales, con fines tecnológicos y de control descritas en las Estructuras de Datos que se encuentran establecidas en los Anexos II: "ESTRUCTURA DE DATOS DTE" y III: "ESTRUCTURA DE DATOS EVENTOS".
2. Haber sido generados en el Formato Electrónico establecido en el punto 1.5 "Formato Electrónico" del Anexo I: "ESPECIFICACIONES TECNOLÓGICAS" para cada tipo de Documento y Evento.
3. Incorporar firma electrónica de conformidad con las condiciones y mecanismos establecidos para el efecto en el punto 2. FIRMA ELECTRÓNICA del Anexo I: "ESPECIFICACIONES TECNOLÓGICAS".
4. Cumplir con los plazos o tiempos asociados a la transmisión de documentos electrónicos y eventos previstos en los puntos 9. TRANSMISIÓN y 12.1 "Transmisión de los Eventos" de la presente Normativa.
5. Cumplir con las reglas de validación para documentos y Eventos establecidas en los Anexos IV: "VALIDACIONES PARA CAMPOS DTE" y V: "VALIDACIONES PARA CAMPOS EVENTOS" de la presente Normativa.

Si cumple con las anteriores reglas, la Administración Tributaria otorgará el Sello de Recepción, con lo cual los documentos electrónicos transmitidos tendrán el carácter de Documentos Tributarios Electrónicos; y respecto a los Eventos, éstos surtirán los efectos de la Invalidación y Contingencia descritos en los puntos 12.3 "Efectos del Evento de Invalidación" y 12.4 "Efectos del Evento de Contingencia" de esta Normativa.

De conformidad a lo dispuesto en el artículo 119-D inciso segundo del Código Tributario, a partir del otorgamiento del Sello de Recepción el Documento Tributario Electrónico surte los efectos fiscales establecidos en el artículo 206 inciso tercero del Código Tributario, por lo que podrá amparar las deducciones de las erogaciones correspondientes.

Los documentos electrónicos transmitidos que no cumplan con las reglas para el otorgamiento del Sello de Recepción, tendrán que ser corregidos o subsanados dentro del plazo de 24 horas contadas a partir de la fecha de comunicación del motivo de rechazo por la Administración Tributaria.

Los documentos electrónicos corregidos que sean retransmitidos para obtener el Sello de Recepción, deberán llevar el mismo Código de Generación que poseían los documentos rechazados originalmente.

En el caso de los Eventos, éstos deberán retransmitirse debidamente corregidos con el mismo Código de Generación que poseían los eventos rechazados originalmente, dentro de los plazos establecidos en los puntos 12.1.1 "Evento de Invalidación" y 12.1.2 "Evento de Contingencia" de esta Normativa.

Una vez transcurridos los anteriores plazos, sin que los respectivos documentos y Eventos hayan sido corregidos o subsanados, los sujetos pasivos deberán transmitir los respectivos documentos y Eventos con un nuevo Código de Generación, a efecto de obtener el Sello de Recepción correspondiente.

En caso la información contenida en el Documento Tributario Electrónico sea alterada posteriormente al otorgamiento del Sello de Recepción por el sujeto pasivo, se considerará Documento Electrónico Apócrifo, por lesión al interés fiscal, sin perjuicio de lo establecido en los artículos 199 incisos segundo y tercero y 206 inciso quinto del Código Tributario.

Asimismo, conforme al inciso tercero del artículo 119-D del Código Tributario, el otorgamiento del Sello de Recepción, no implica validación o autorización alguna de la operación que se documenta, no obstante, el otorgamiento o no del citado Sello no afecta la validez jurídica de la operación o negocio efectuado. Su otorgamiento tampoco implica que el documento no pueda ser objetado por la Administración Tributaria en el ejercicio de sus facultades legales.
10.1. Estados de los documentos

Realizado el proceso para la obtención del Sello de Recepción, los documentos transmitidos podrán tener los siguientes estados:

- Transmitido satisfactoriamente: Habiendo obtenido el Sello de Recepción se tiene por efectuada la transmisión, adquiriendo el carácter de Documento Tributario Electrónico. Dentro de este Estado se presentan las siguientes condiciones:
- Ajustado: Cuando el documento transmitido ha sido objeto de ajustes mediante otro documento transmitido, que afectan la operación.
- Observado: El documento tiene observaciones de la Administración Tributaria, que no afectan su validez jurídica.
- Rechazado: El documento no obtuvo el Sello de Recepción. No podrá amparar las deducciones de las erogaciones correspondientes; no obstante, conforme al inciso primero del artículo 199 del Código Tributario, presumirá que ha sido generado para documentar ingresos por las transferencias de bienes o prestación de servicios gravadas.
- Invalidado: El documento obtuvo el Sello de Recepción, pero posteriormente el emisor transmitió un Evento de Invalidación para invalidarlo. El documento invalidado no posee validez tributaria y quedará sin valor alguno la versión interpretada y legible entregada.

10.2. Registro y declaración de los DTE

Los documentos deberán registrarse en los libros de control del Impuesto a la Transferencia de Bienes Muebles y a la Prestación de Servicios y en la contabilidad, según el caso, con la fecha en que fueron generados, utilizando el Código de Generación, inclusive cuando no hubiesen sido transmitidos; lo anterior, sin perjuicio de lo dispuesto en el artículo 119-C inciso quinto del Código Tributario, que establece que los Documentos Tributarios Electrónicos han sido emitidos a partir de la fecha en que la Administración Tributaria otorgue el Sello de Recepción.

Los receptores de documentos que excepcionalmente fueron generados por los sujetos pasivos sin Sello de Recepción conforme a lo establecido en el punto 11.2 "Entrega con Transmisión Diferida" de esta Normativa, deberán consultar en el sitio web del Ministerio de Hacienda, que los documentos recibidos cuentan con el citado Sello, a efecto que amparen las deducciones de las erogaciones correspondientes.

Asimismo, los sujetos pasivos deberán incorporar en sus declaraciones del Impuesto a la Transferencia de Bienes Muebles y a la Prestación de Servicios, los documentos del período tributario en que fueron generados.

11.1 Entrega con Transmisión Previa

Los Documentos Tributarios Electrónicos generados y transmitidos a la Administración Tributaria, deberán entregarse incorporando el Sello de Recepción otorgado por la misma de forma electrónica al receptor, en la modalidad establecida en el numeral 6.1 de la presente Normativa.

Conforme a lo dispuesto en el artículo 119-C inciso sexto del Código Tributario, es obligación de los receptores exigir la entrega de los Documentos Tributarios Electrónicos, lo que implica que deberán exigirlos con el respectivo Sello de Recepción otorgado por la Administración Tributaria, excepto en los casos de Contingencia, que no contarán con dicho Sello, pero deberán expresar en su contenido el valor de campo "Tipo de Transmisión por contingencia" Código 2, conforme al CAT-004 Tipo de Transmisión.

El fedatario no se encuentra obligado a exigir la emisión de los Documentos Tributarios Electrónicos, por ende, podrá en sus actuaciones verificar el cumplimiento de la obligación de emitir dichos documentos. Lo anterior, sin perjuicio de lo establecido en los artículos 179, 180 y 181 del Código Tributario.
11.2 Entrega con Transmisión Diferida

Los documentos electrónicos generados en la modalidad establecida en el numeral 6.2 "Emisión con Transmisión Diferida a la Administración Tributaria" de la presente Normativa, se entregarán al receptor de forma electrónica sin contar con el Sello de Recepción, no obstante, la transmisión de los documentos se deberá realizar posteriormente a la Administración Tributaria conforme a lo establecido en el punto 9 "Transmisión" de esta Normativa.

En ese sentido, deberá entregarse el formato electrónico del documento firmado (sin el Sello de Recepción) y su versión interpretada y legible.

Sin perjuicio de lo anterior, de conformidad al inciso primero del artículo 199 del Código Tributario, se presumirá que los documentos firmados no transmitidos, han sido generados para documentar ingresos por las transferencias de bienes o prestación de servicios gravadas.
11.3 Versiones interpretadas y legibles del Documento Tributario Electrónico

De conformidad a lo dispuesto en el artículo 119-A inciso primero literal e) del Código Tributario, los sujetos pasivos deberán generar y entregar en todo caso una versión electrónica interpretada del DTE, que sea legible para el receptor.

La versión electrónica interpretada del DTE como expresión del mismo, deberá generarse de manera simultánea y entregarse junto con dicho DTE por cada operación que realicen los sujetos pasivos.

Estas versiones no tendrán validez probatoria en los mismos términos concedidos a los Documentos Tributarios Electrónicos que representan; su finalidad es la de expresar con claridad los datos de los citados documentos de forma ordenada y fácilmente comprensible para el usuario.

Dichas versiones reciben el nombre genérico de Representación Gráfica, que deberán entregarse utilizando las tecnologías que mejor resuelvan el modelo de negocio del sujeto pasivo.

Las versiones electrónicas interpretadas y legibles del DTE, deberán integrar un parámetro de consulta dentro de un Código QR. Los parámetros respectivos se establecen en el "Manual Tecnológico para la Integración del Sistema de Transmisión".

Los contenidos, características y especificaciones que deberán cumplir dichas versiones legibles se categorizan conforme a lo dispuesto en la columna "Versión legible" de la estructura contenida en el Anexo II: "ESTRUCTURA DE DATOS DTE" de esta Normativa.

Los sujetos pasivos deberán utilizar el diseño gráfico idóneo para el cumplimiento de los mismos.
12. Conservación de los DTE

Los Documentos Tributarios Electrónicos deberán ser conservados electrónicamente de forma segura e inalterable durante el plazo exigido en el artículo 147 del Código Tributario, es decir, conservando con exactitud la misma información, estructura de datos y formato electrónico con que fueron generados, firmados y transmitidos a la Administración Tributaria.

De la misma forma deberán conservarse los documentos tributarios firmados y entregados que no han sido transmitidos a la Administración Tributaria.
12.1 Anulación y destrucción de documentos físicos

Los documentos físicos relativos al control del Impuesto a la Transferencia de Bienes Muebles y a la Prestación de Servicios y comprobantes de donación impresos que ya no deban utilizarse, por haber sido reemplazados por DTE, tendrán que ser presentados a la Administración Tributaria para su anulación y destrucción. Asimismo, deberá informarse los correlativos autorizados que ya no deban ser utilizados de conformidad a lo antes establecido.

A excepción de los sujetos pasivos que utilicen únicamente la plataforma "Sistema de Facturación DTE" operable dentro de la página web del Ministerio de Hacienda, ningún sujeto pasivo podrá mantener documentos físicos o impresos, mientras la Administración Tributaria no establezca otra condición.

Para efecto de lo establecido en el párrafo anterior, se entiende por documentos impresos inclusive a los sistemas de emisión de documentos digitales, portables o imágenes, que no poseen la estructura de datos ni el formato electrónico establecido por la Administración Tributaria.
13. Eventos

De conformidad con lo establecido en los artículos 119-E y 119-F del Código Tributario. los Eventos relacionados con los Documentos Tributarios Electrónicos son los siguientes:
a) Evento de Invalidación.
b) Evento de Contingencia.

La Estructura de Datos de los citados Eventos se encuentra establecida en el Anexo III: "ESTRUCTURA DE DATOS EVENTOS" de la presente Normativa.

Conforme a lo dispuesto en el artículo 119-A inciso primero literal g) del Código Tributario, la Administración Tributaria podrá establecer otros Eventos relacionados a los DTE, mediante la modificación a la presente Normativa.
13.1 Transmisión de los Eventos

De conformidad a lo establecido en el inciso cuarto del artículo 119-D del Código Tributario, deberán transmitirse los eventos de invalidación y de contingencia, informando los Documentos Tributarios Electrónicos que serán invalidados o que fueron emitidos en contingencia. La transmisión de los referidos Eventos deberá efectuarse de esta manera:

13.1.1 Evento de Invalidación

| No. | Base Legal | Tipo de documento relacionado con el Evento | Caso | Condición | Plazo para Transmitir el Evento |
| :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | Art. 119-E inc. 1 literal a) Código Tributario | Todos los documentos descritos en el numeral 4 de la presente Normativa. | Errores que no impliquen ajuste a la operación o negocio subyacente celebrado con el receptor, sino la invalidación del DTE que tiene el dato errado. | Que el error ocurra por causa del emisor en el ingreso de los datos de un DTE. Por ejemplo: Equivocación cometida al introducir los datos de la fecha, nombre o descripción, entre otros, en el documento. | Un día siguiente al otorgamiento del Sello de Recepción. |
| 2 | Art. 119-A inc. 1 lit. g) Código Tributario | CCFE, NRE, NCE, NDE, CLE, CRE, DCLE, FSEE y CDE del numeral 4 de la presente Normativa | Cuando se rescinda totalmente la operación. | Que se rescinda totalmente la operación o negocio celebrado con el receptor. Por ejemplo: Cuando ocurra la devolución de los bienes vendidos. | Un día siguiente al otorgamiento del Sello de Recepción. |
| 3 | Art. 119-E inc. 2 Código Tributario | FE y FEXE del numeral 4 de la presente Normativa | Cuando se rescinda totalmente la operación o se afecten las operaciones realizadas. | Que se rescinda o modifique la operación o negocio celebrado con el receptor. Por ejemplo: La reducción del precio del bien o servicio prestado o cambio de un producto o servicio diferente. | Dentro de tres meses contados a partir del otorgamiento del Sello de Recepción del documento a invalidar. |

Cuadro 2: Invalidación

13.1.2 Evento de Contingencia

Previo a considerarse en contingencia, el emisor deberá cerciorarse de haber agotado la "política de reintentos" establecida en el "Manual Tecnológico para la Integración del Sistema de Transmisión".

| No. | Base Legal | Tipo de documento relacionado con el Evento | Caso | Condición | Plazo para Transmitir el Evento |
| :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | Arts. 119A inc. 1 lit. g) y 119-F Código Tributario | Únicamente CCFE, FE, FEXE, NRE, NCE, NDE y FSEE del numeral 4 de la presente Normativa. | Cuando se presenten situaciones de fuerza mayor que imposibiliten la transmisión de los documentos electrónicos a la Administración Tributaria. | Que el imprevisto no es posible resistir. Por ejemplo: Fallas ocasionadas por los proveedores en el suministro del servicio de Internet o indisponibilidad de acceso a la plataforma informática establecida por la Administración Tributaria. | 24 horas contadas a partir del cese de la situación de fuerza mayor que provocó la contingencia. |

Cuadro 3: Contingencia

El emisor deberá reiniciar los reintentos como mínimo cada quince minutos para asegurarse del restablecimiento de la conectividad del sistema de emisión DTE con los servicios de la Administración Tributaria.
13.2 Lineamientos para el evento de invalidación

A excepción de la Nota de Crédito electrónica y el Comprobante de Liquidación electrónico, cuando el motivo del Evento de Invalidación sea distinto a la rescisión total de la operación, previo a la transmisión del citado Evento, deberá generarse y transmitirse el nuevo documento que ampara la operación, debido a que la estructura del Evento de Invalidación contiene tanto la identificación del documento a invalidar como del nuevo documento que ampara la operación.

En todo caso, la invalidación únicamente procederá respecto de documentos tributarios que hayan obtenido previamente el Sello de Recepción.
13.2.1 Reglas para invalidación de Facturas y Facturas de Exportación Electrónicas

Cuando se trate de la invalidación de facturas electrónicas y facturas de exportación electrónicas, por ajustes a las ventas que rebajen el débito fiscal, ésta deberá realizarse dentro del plazo de tres meses contados a partir de la fecha de la entrega de los bienes o a partir de la fecha en la que se preste el servicio.

Respecto de las operaciones cuyo monto total sea menor a tres salarios minimos mensuales, conforme a lo dispuesto en el artículo 119-G inciso primero literal b) número VII del Código Tributario cuando se trate de Facturas electrónicas no será requerido la identificación del Receptor para el otorgamiento del Sello de Recepción.

No obstante lo anterior, cuando se trate de un Evento de Invalidación de Factura electrónica, será condición indicar el nombre y documento de identificación de la persona que solicita la invalidación ante el sujeto pasivo emisor, además del nombre y documento de identificación del responsable de realizar dicho Evento por parte del emisor.
13.2.2 Diferencia entre error y afectación

Se considera que existe error que no afecta la operación, cuando se trate de omisiones o inexactitudes en los datos introducidos al DTE respecto de la transacción que se está documentando, por ejemplo, cuando el precio de los bienes convenido en la operación difiera por error del documentado.

La afectación implica una modificación realizada a una transacción previamente documentada, por ejemplo, cuando el precio convenido en la operación sea modificado posteriormente por una nueva negociación.

Por lo tanto, conforme a lo dispuesto en el artículo 119-E inciso cuarto del Código Tributario, si no se trata de la corrección de errores, los Comprobantes de Crédito Fiscal y Comprobantes de Retención que hayan obtenido el Sello de Recepción, deberán ser modificados para ajustar el débito o crédito fiscal del Impuesto a la Transferencia de Bienes Muebles y a la Prestación de Servicios, mediante Notas de Débito o Crédito, según corresponda, en los plazos establecidos para tal efecto en la Ley de la materia.
13.3 Efectos del Evento de Invalidación

Una vez el Evento de Invalidación transmitido dentro de los plazos establecidos en el cuadro 2: "Invalidación" haya obtenido el Sello de Recepción, el Documento Tributario Electrónico relacionado con él quedará invalidado y no podrá utilizarse para amparar deducciones del Impuesto sobre la Renta y del Impuesto a la Transferencia de Bienes Muebles y a la Prestación de Servicios.

En este caso, al sujeto pasivo emisor no le será aplicable la sanción establecida en el artículo 239A inciso primero literales g) y h) del Código Tributario.

Transcurridos los plazos establecidos en el Cuadro 2: Invalidación, los documentos no podrán invalidarse mediante la transmisión del Evento de Invalidación.

Las invalidaciones de los DTE no constituyen ajustes al débito o crédito fiscal, por lo tanto, no le son aplicables las reglas o plazos establecidos en los artículos 62 y 63 de la Ley de Impuesto a la Transferencia de Bienes Muebles y a la Prestación de Servicios.

Por lo anterior, las declaraciones del referido impuesto deberán sujetarse a las siguientes reglas:
a. Si el Evento obtiene el Sello de Recepción en el mismo periodo tributario de emisión del DTE objeto de invalidación, no ocasionará modificación alguna en la declaración del período tributario.
b. Si el Evento obtiene el Sello de Recepción en un periodo tributario posterior al de la emisión del DTE objeto de invalidación, esta invalidación deberá reflejarse en la declaración del período tributario en que obtuvo el Sello de Recepción el Evento de Invalidación.
13.4 Efectos del Evento de Contingencia

Una vez el Evento de Contingencia transmitido dentro del plazo establecido en el cuadro 3: "Contingencia" haya obtenido el Sello de Recepción, los documentos electrónicos generados y firmados en contingencia deberán transmitirse a la Administración Tributaria en un plazo no mayor a setenta y dos horas contadas a partir de la obtención del citado Sello.

En este caso, al sujeto pasivo emisor no le será aplicable la sanción establecida en el artículo 239A inciso primero literales g) y h) del Código Tributario.

Cuando la contingencia persista por más de cuatro días consecutivos, el sujeto pasivo deberá presentar un Informe Técnico en las siguientes cuarenta y ocho horas dirigido a la Administración Tributaria, en el que deberá exponer las causas que producen la contingencia y los motivos para
no superarla, indicando su plan de acciones a implementar para solventar la misma, asi como las medidas de control interno que tomará para prevenir la recurrencia de tales situaciones.

El citado Informe Técnico se presentará en la forma que establezca la Administración Tributaria.
Las declaraciones del Impuesto a la Transferencia de Bienes Muebles y a la Prestación de Servicios deberán reflejar las operaciones realizadas y documentadas en contingencia, una vez los documentos respectivos cuenten con el Sello de Recepción, sin perjuicio de la sanción establecida en el artículo 239-A literal a) del Código Tributario, respecto de las operaciones cuyos documentos no sean transmitidos a la Administración Tributaria.

La entrega del documento electrónico en contingencia sin contar con el Sello de Recepción no exime a los emisores de la obligación de transmitir los documentos a la Administración Tributaria para el otorgamiento del citado Sello de Recepción, sin perjuicio de las sanciones establecidas en el artículo 239-A literales a) y d) del Código Tributario, en caso no obtengan el referido Sello o no sean transmitidos a la Administración Tributaria.

Lo anterior no es aplicable para los sujetos pasivos usuarios de la aplicación web denominada "Sistema de Facturación DTE", los cuales mientras dure la contingencia, podrán utilizar los documentos con numeración correlativa previamente autorizada (documentos preimpresos por imprenta, Formulario único y Sistemas de emisión de documentos mediante imprentas digitales (PDF)), mientras la Administración Tributaria no determine otra opción.
14. Consulta

El receptor podrá consultar el estado de los Documentos Tributarios Electrónicos recibidos, en el sitio web del Ministerio de Hacienda, para cerciorarse que estos hayan obtenido el Sello de Recepción, a afecto de respaldar debidamente las deducciones correspondientes.

La consulta de los Documentos Tributarios Electrónicos se puede efectuar en el sitio web de facturación electrónica del Ministerio de Hacienda, durante el plazo que establezca la Administración Tributaria.

Los emisores de Documentos Tributarios Electrónicos podrán consultar los documentos emitidos y recibidos, mediante la página web del Ministerio de Hacienda.
15. Coexistencia

Los sujetos pasivos emisores de Documentos Tributarios Electrónicos de conformidad a las fechas establecidas en el Programa de Implementación establecido por la Administración Tributaria, que poseen autorizaciones para el uso de documentos equivalentes (tiquetes) a que se refiere el articulo 107 inciso segundo del Código Tributario, emitidos mediante máquinas registradoras o sistemas computarizados, podrán continuar utilizándolos hasta el 31 de diciembre de $2024 .^1$

A partir del 1 de enero de $2025 .{ }^1$ los sujetos pasivos emisores de Documentos Tributarios Electrónicos, no podrán seguir utilizando documentos equivalentes (tiquetes), por lo que deberán emitir Factura Electrónica por las operaciones que realicen con consumidores finales.

¹ Control de Cambios No. 1.1 Modificación 4 de junio de 2024
Asimismo, a partir de la sustitución de tiquetes por Factura Electrónica, los carteles de Caja Registradora entregados por la Administración Tributaria cesarán totalmente en sus efectos.

16. Gratuidad

Para los efectos establecidos en el artículo 119-H del Código Tributario, la Administración Tributaria pondrá a disposición de los sujetos pasivos una aplicación web para la emisión de los DTE, denominada "Sistema de Facturación DTE" operable dentro de la página web del Ministerio de Hacienda.

Dicha solución está dispuesta para los sujetos pasivos que cumplen los parámetros establecidos por la Administración Tributaria.

Asimismo, proveerá a los sujetos pasivos de otras soluciones tecnológicas gratuitas que considere pertinentes.
17. Programa de Implementación

La Administración Tributaria establecerá los grupos de contribuyentes y las fechas de inicio de la obligación para emitir los Documentos Tributarios Electrónicos.

Los contribuyentes obligados en cada grupo serán notificados por la Administración Tributaria a través de los medios pertinentes. La transmisión de los citados documentos a la plataforma informática establecida por esta Administración Tributaria, deberá comenzar a partir de las fechas de inicio de la obligación para emitir los DTE establecida en el Programa de Implementación respectivo.

Los contribuyentes emisores de DTE deberán implementar en todos sus establecimientos, todos los tipos de documentos tributarios que emiten de conformidad a su operatividad y obligaciones; es decir, los mismos que le han sido autorizados por la Administración Tributaria además de cualquier otro que surja de su operatividad.
Los contribuyentes podrán optar por iniciar la emisión de DTE previo a la fecha establecida por la Administración Tributaria.

Los contribuyentes para ser emisores de DTE, según la plataforma a utilizar, deberán cumplir con los siguientes requisitos:
a) Sistema de Transmisión: Contar con un sistema de emisión de DTE, de acuerdo a las disposiciones pertinentes del Código Tributario, de esta Normativa y de las Guías y Manuales emitidos por la Administración Tributaria para tal efecto. Asimismo, deberán completar satisfactoriamente las pruebas requeridas.
b) Sistema de Facturación: Cumplir con los parámetros definidos por la Administración Tributaria para la emisión de DTE y completar satisfactoriamente las pruebas de adaptación requeridas.
18. Fechas y condiciones para liberación de la presentación de informes

Conforme al artículo 119-A inciso primero literal i) del Código Tributario, la Administración Tributaria establecerá oportunamente las fechas a partir de las cuales los sujetos pasivos que emitan DTE, quedarán liberados de las obligaciones de presentación de los informes regulados en dicho Código.
19. Lineamientos para Versiones y Modificaciones de la Normativa

Cuando deba actualizarse la presente Normativa los sujetos pasivos deberán realizar las adaptaciones necesarias dentro de los siguientes plazos:

\begin{tabular}{|l|l|l|l|}
\hline No. & Tipo & Contenido & Plazo de adaptación \\
\hline 1 & Versiones & Cambios sustanciales en las estructuras de datos, formato electrónico o firma de los DTE y Eventos. & Dentro de los diez primeros días hábiles del tercer mes que sigue al período tributario en que fue comunicado el cambio, a excepción de la versión 1.0 (inicial). \\
\hline 2 & Modificaciones & Cambios mínimos en las estructuras de datos de los DTE y Eventos. & Dentro de los diez primeros días hábiles del mes siguiente al período tributario en que fue comunicado el cambio. \\
\hline
\end{tabular}

Cuadro 4: Modificaciones y Versiones
Los cambios en esta Normativa que no afecten las estructuras de datos, formato electrónico o firma de los DTE y Eventos, tendrán vigencia a partir del día de su publicación.

La Administración Tributaria no otorgará el Sello de Recepción a los DTE y Eventos que no apliquen los cambios respectivos dentro de los plazos de adaptación establecidos en el cuadro 4 anterior.
20. Anexos

Los siguientes Anexos forman parte integrante de la presente Normativa:
ANEXO I: ESPECIFICACIONES TECNOLÓGICAS
ANEXO II: ESTRUCTURA DE DATOS DTE
ANEXO III: ESTRUCTURA DE DATOS EVENTOS
ANEXO IV: VALIDACIONES PARA CAMPOS DTE
ANEXO V: VALIDACIONES PARA CAMPOS EVENTOS
21. Vigencia

La presente Normativa estará vigente a partir de la fecha de su emisión.
San Salvador, 4 de junio de 2024.

Marvin Esau Sorto
Director General
Dirección General de Impuestos Internos



ANEXOI
ESPECIFICACIONES TECNOLÓGICAS
De conformidad a lo dispuesto en el artículo 119-A inciso primero literales b), c) y g) del Código Tributario, el presente anexo comprende las instrucciones y especificaciones tecnológicas requeridas para la emisión de los DTE y Eventos.
1. GENERACIÓN DE LOS DTE
1.1. Código de Generación

Es un UUID o Identificador Único Universal formado por un número de 16 bytes ( 128 bits). Se expresa mediante 32 digitos hexadecimales divididos en cinco grupos separados por guiones de la forma 8-4-4-4-12 que totalizan 36 caracteres, utilizando letras mayúsculas (32 digitos y 4 guiones). Se utilizará UUID versión 4 .

Por ejemplo: 550E8400-E29B-41D4-A716-446655440000
La generación del UUID versión 4 es diferente según el lenguaje de programación que se utilice, el emisor deberá utilizar la librería correspondiente a la tecnología utilizada en sus sistemas. Este UUID será la estructura requerida por la Administración Tributaria para la creación del Código de Generación dentro del DTE y Evento emitido y será responsabilidad de cada emisor la generación de este código.

El archivo DTE deberá identificarse con el Código de Generación.
1.2. Campos y Secciones

Los sujetos pasivos deberán implementar las Estructuras de Datos que integran el formato electrónico JSON para la generación de los DTE.

Las Estructuras de los Documentos Tributarios Electrónicos son indicaciones del contenido y de las especificaciones que deben cumplirse según el documento tributario que se esté generando; de conformidad a lo establecido por la Administración Tributaria.

Estas estructuras están divididas en campos y secciones.
Los campos de los documentos son la información (datos) que la Administración Tributaria requiere para generar, transmitir y recibir un DTE; es importante mencionar que cada tipo de documento contiene sus campos con información especifica.

Las secciones son agrupaciones de campos con información relacionada, en que se han dividido las estructuras de los documentos tributarios, estas secciones son:
1. Sección "Identificación": Sección obligatoria incluida en todas las estructuras, donde se detallan las generales del documento que se está generando.
2. Sección "Documentos Relacionados": Este apartado deberá llenarse si existiere documento a relacionar.
3. Sección "Emisor": Sección obligatoria incluida en todos los documentos tributarios, donde se describen los datos del emisor del documento. Es importante destacar que esta sección puede llamarse de otras formas dependiendo del documento que se esté generando, de la siguiente forma: Exportador para la FEXE, Agente de retención para el CRE, Comisionista para el CLE, Agente perceptor para el DCLE y Donatario para el CDE.
4. Sección "Receptor": En esta sección se describen los datos generales de quien está recibiendo el documento tributario. Puede variar su nombre dependiendo del documento realizado de la siguiente forma: Sujeto de retención para el CRE, Mandante para el CLE, Afiliado para el DCLE y Donante para el CDE.
5. Sección "Documentos asociados": Esta sección es opcional para la mayoría de los documentos tributarios, y permite anexar información relevante de la operación; esta información puede ser del emisor (contratos, resoluciones, etc.), del receptor (contratos, resoluciones, autorizaciones, etc.), del médico (identificación, nombre, procedimiento, etc.) y del medio de transporte (identificación, conductor, entre otros). Es obligatorio solo para el CDE.
6. Sección "Venta a cuenta de terceros": Utilizada para describir la información del sujeto pasivo a cuenta de quien se está realizando la venta, incluida en la mayoría de los documentos tributarios, exceptuando el CRE, DCLE, CLE, FSEE y CDE.
7. Sección "Cuerpo del documento": Sección obligatoria para todos los documentos tributarios, en esta sección se detalla la información propia de cada documento tributario.
8. Sección "Resumen": Contiene un resumen general de la información del cuerpo del documento, es obligatoria y se encuentra en todos los documentos tributarios, excepto en el DCLE.
9. Sección "Extensión": Se detalla entre otros los datos generales de los responsables de entregar y recibir el documento, esta sección es opcional para los DTE exceptuando el DCLE.
10. Sección "Apéndice": Esta sección es opcional y se encuentra a disposición para incluir cualquier otra información dentro de los documentos.

El "Sello de Recepción" no es una sección ni un campo de los documentos tributarios, se incorpora con la finalidad de hacer del conocimiento al sujeto pasivo que la Administración Tributaria enviará un código encriptado con ese nombre, por cada documento tributario que haya sido correctamente transmitido.

Asimismo, las especificaciones de cada campo se han detallado en las siguientes columnas:
1. $N^{\circ}$ de campo: Número secuencial que identifica cada campo en un documento Tributario.
2. $\mathrm{N}^{\circ}$ Sección: Contiene el número de sección a la cual pertenece cada campo.
3. Campo JSON: Esta columna contiene el nombre de la sección y del campo en el JSON a generar del documento.
4. Versión legible: Esta columna indica si el campo debe ser colocado en la versión interpretada y legible del documento, según una codificación alfabética.
5. Nombre del Campo: Contiene el nombre asignado a cada campo.
6. Descripción de contenido del campo: Esta columna describe la información específica requerida en cada campo (valores, datos, códigos entre otros); pueden encontrarse fórmulas para determinar el campo, ejemplos y algunas condiciones especiales.
7. Condición del campo: Determina si el campo es "Requerido para su transmisión", "Requerido por tipo de operación" u "Opcional", conforme se detalla en el punto 1.3 "Definición de condiciones de campo" de este anexo.
8. Tipo de dato: Columna que detalla si el campo es numérico o alfanumérico.
9. Longitud/precisión: Contiene la extensión permitida para el campo.


1.3. Definición de condiciones de campo

Un campo es un espacio de almacenamiento para un dato en particular contenido en la Estructura de Datos de los DTE que se detalla en el Anexo II: "ESTRUCTURA DE DATOS DTE". Cada campo de la estructura comprende las siguientes condiciones:
i. Requerido para su transmisión: Se coloca esta condición a los campos requeridos por la Administración Tributaria en la estructura JSON. Se rechazarán los documentos que no contengan estos campos con la información requerida.
ii. Requerido por tipo de operación: Se coloca esta condición a los campos que deberán completarse cuando el tipo de operación o modalidad del negocio que se está desarrollando lo requiera, ya sea por condiciones de lugar, giro o por el tipo de obligaciones que se le ha asignado al sujeto pasivo.
iii. Opcional: Esta condición se coloca a los campos que dependiendo de la necesidad de cada sujeto pasivo podrá hacer uso o no de ellos.

Cuando existan campos o secciones que por tipo de operación o modalidad del negocio no sean utilizados y éstos tengan asignada la condición Requerido por tipo de operación u Opcional, se deberán completar siguiendo las siguientes reglas:

Campos numéricos: Deberán completarse con 0.00.
Campos alfanuméricos: Deberán completarse con null.
Sección completa: Podrá completarse con null.
1.3.1. Restricciones de uso en los campos de los DTE

No se permitirá en los campos de los DTE:
- Simbolos de monedas en los campos monetarios (\$., . B.
- Exceder la longitud establecida por tipo de campo.
- Información no pertinente.
- Imágenes.
- Signo para valores negativos en los campos numéricos (-). No obstante, se podrá reflejar valores negativos en:
- Campo "Cargos / Abonos que no afectan la base imponible" en Comprobante de Crédito Fiscal electrónico, Factura y Factura de Exportación electrónicas.
- Cuando en el Comprobante de Liquidación Electrónico se registre la Nota de Crédito Electrónica y los documentos invalidados.
1.4. Estructura de Datos

La Estructura de Datos de los DTE y Eventos, es un listado organizado de todos los datos pertinentes que comprende los elementos o campos que integran el formato electrónico del documento, se encuentran en los Anexos II: "ESTRUCTURA DE DATOS DTE" y III: "ESTRUCTURA DE DATOS EVENTOS", respectivamente.
1.5. Formato Electrónico

El formato electrónico de los DTE y Eventos se basa en un esquema JSON (JSON-schema). El esquema define los elementos y atributos que aparecen en los documentos JSON.

Se proporciona una muestra de dicho esquema a continuación:


```
"identificacion": {
    "version": 3,
    "ambiente": "00",
    "tipoDte": "03",
    "numeroControl": "DTE-03-M001P001-000000000000002",
    "codigoGeneracion": "516413E3-12A2-78D5-7A79-6B6DFE861395",
    "tipoModelo": 1,
    "tipoOperacion": 1,
    "tipoContingencia": null,
    "motivoContin": null,
    "fecEmi": "2022-10-20",
    "horEmi": "11:02:49",
    "tipoMoneda": "USD"
},
"documentoRelacionado": null,
"emisor": {
    "nit": " ",
    "nrc": " ",
    "nombre": " ",
    "codActividad": "62020",
    "descActividad": " ",
    "nombreComercial": " ",
    "tipoEstablecimiento": "02",
    "direccion": {
    "departamento": "06",
    "municipio": "14",
    "complemento": " "
},
"t
"corre"," " '
    "correo": " ",
    "codEstable": null,
    "codPuntoVenta": null,
    "codEstableMH": "4577",
    "codPuntoVentaMH": "4578"
},
"receptor": {
    "nrc": " ",
    "nombre": " ",
    "codActividad": "46495",
    "descActividad": " ",
    "direccion": {
    "departamento": "05",
    "municipio": "06",
    "complemento": " "
},
    "telefono": " ",
    "correo": " ",
    "nombreComercial": " ",
    "nit": " "
},
"cuerpoDocumento": [
{
    "numltem": 1,
    "tipoltem": 2,
    "cantidad": 1,
    "codigo": " ",
    "uniMedida": 99,
    "descripcion": " ",
    "precioUni": 0,
    "montoDescu": 0,
    "codTributo": null,
    "ventaNoSuj": 0,
    "ventaExenta": 0,
    "ventaGravada": 0,
    "tributos": [
        "20"
    ],
    "psv": 0,
    "noGravado": 0
},
],
"resumen": {
    "totalNoSuj": 0,
    "totalExenta": 0,
    "totalGravada": 0,
    "subTotalVentas": 0,
    "descuNoSuj": 0,
    "descuExenta": 0,
    "descuGravada": 0,
    "porcentajeDescuento": 0,
    "totalDescu": 0,
    "tributos": [
    {
        "codigo": " ",
        "descripcion": "IVA",
        "valor": 0
    }
    ],
    "subTotal": 0,
    "ivaPerci1": 0,
    "ivaRete1": 0,
    "reteRenta": 0,
    "montoTotalOperacion": 0,
    "totalNoGravado": 0,
    "totalPagar": 0,
    "totalLetras": " ",
    "saldoFavor": 0,
    "condicionOperacion": 1,
    "pagos": null,
    "numPagoElectronico": null
},
"extension": {
    "nombEntrega": " ",
    "docuEntrega":
    "nombRecibe":
    "docuRecibe": "
    "placaVehiculo"
    "observaciones": " "
},
"apendice": null,
```

Los JSON de cada DTE y Evento se corresponden con la columna "campo JSON" de las Estructura de Datos de los Anexos II: "ESTRUCTURA DE DATOS DTE" y III: "ESTRUCTURA DE DATOS EVENTOS".

La Administración Tributaria pondrá a disposición de los sujetos pasivos los JSON-schema por el medio que estime conveniente. Dichos esquemas son herramientas útiles para validar y especificar la estructura de los documentos JSON.
1.6. Reglas para el otorgamiento del Sello de Recepción de los DTE y Eventos

La Administración Tributaria otorgará Sello de Recepción a los documentos transmitidos que cumplan con las reglas previstas en el punto 10 "Reglas para el otorgamiento del Sello de Recepción" de esta Normativa, conforme al ejemplo que se muestra a continuación:
"selloRecepcion": "2022B37C057541BB4B9B98580A0D1463D6B0A77Z"
Sin perjuicio de las validaciones descritas en los Anexos IV: "VALIDACIONES PARA CAMPOS DTE" y V: "VALIDACIONES PARA CAMPOS EVENTOS" de esta Normativa y de las demás de uso interno de la Administración Tributaria, se aplicarán las siguientes reglas de redondeos y holguras para los DTE:
1.7. Catálogos

Los catálogos son una lista sistematizada de codificaciones donde se refleja información importante sobre los campos que se utilizan en los diferentes DTE; estos catálogos permiten conocer y localizar los diferentes códigos asignados para describir la información clasificada por grupos de acuerdo a los diferentes campos contenidos en las estructuras de los mencionados documentos.

Los catálogos de los Documentos Tributarios Electrónicos serán establecidos por la Administración Tributaria, su utilización será obligatoria y estarán disponibles en la forma que ésta establezca.
2. FIRMA ELECTRÓNICA
2.1. Condiciones y mecanismos

En relación al modelo de firma electrónica para los Documentos Tributarios Electrónicos, se utilizará la firma electrónica simple, mientras la Administración Tributaria no designe un mecanismo de firma diferente. La Administración Tributaria es la responsable de la emisión y resguardo de la información de los certificados de firma simple.

La validación de los referidos certificados la realizará la Administración Tributaria sobre cada documento transmitido.

Es responsabilidad del emisor administrar su propia infraestructura y software de firma electrónica, que le permita firmar todos los Documentos Tributarios Electrónicos generados.

La firma electrónica del documento se realizará conforme a los siguientes mecanismos:

\begin{tabular}{|l|l|}
\hline Firmado de Documentos & JSON Web Signature (JWS) \\
\hline Estándar de Firmado & \begin{tabular}{l} 
CAdES - PKCS8EncodedKeySpec y como algoritmo de \\
encriptado RSA512
\end{tabular} \\
\hline
\end{tabular}

La firma electrónica deberá encriptar el documento tributario y los eventos de contingencia e invalidación, utilizando la información especificada en el certificado electrónico proporcionado por la Administración Tributaria.

Se proporciona una muestra a continuación:
"firma":
"eyJhbGciOiJSUzUxMiJ9.ewogICJpZGVudGlmaWNhY2lvbilgOiB7CiAgICAidmVyc2lvbilgOiAzLAogl CAgImFtYmllbnRIliA6ICIwMCIsCiAgICAidGlwb0R0ZSIgOiAiMDMiLAogICAgIm51bWVyb0NvbnRyb2 wilDoglkRURSOwMyOONTc3NDU3OC0wMDAwMDAwMDAwMDAwMDliLAogICAgImNvZGInbOdl bmVyYWNpb24ilDogljUxNjQxMOUzLTExQTItNDNENS05QTc5LTZCNkRGRTg2MTM5MSIsCiAgICA idGlwb01vZGVsbyIgOiAxLAogICAgInRpcG9PcGVyYWNpb24ilDogMSwKICAgICJOaXBvQ29udGluZ 2VuY2lhliA6IG51bGwsCiAgICAibW90aXZvQ29udGluliA6IG51bGwsCiAgICAiZmVjRW1pliA6IClyMDI yLTEwLTIwliwKICAgICJob3JFbWkiIDogljExOjAyOjQ5liwKICAgICJOaXBvTW9uZWRhliA6ICJVU0Qi 6HASpRxeZLTrwkPutbVsYCrXHGYZmenLAKU4VI1SbHIUUCKAUIDIBSA.

Los códigos generados en el proceso de obtención de claves para la transmisión de documentos serán de criptografia asimétrica:

Llave privada: Es la que permite cifrar la información del documento, es decir, convertir los datos de un formato legible a un codificado. Su uso es privado y exclusivo del titular del certificado.

Llave pública: Es la que permite descifrar la información. Puede compartirse con los sujetos que requieran utilizar la información cifrada.

Certificado: Contiene el certificado de firma emitido por la Administración Tributaria.
3. TRANSMISIÓN

La forma y condiciones para la Transmisión de los Documentos Tributarios Electrónicos se establecen a continuación.

3.1. Ambientes de Transmisión

La Administración Tributaria dispone de los siguientes ambientes para la transmisión de los Documentos Tributarios Electrónicos:
- Ambiente para Pruebas: En este ambiente el sujeto pasivo deberá realizar las pruebas necesarias para cerciorarse de la correcta transmisión de los Documentos Tributarios Electrónicos.
- Ambiente Productivo: Una vez finalizadas las pruebas necesarias, en este ambiente el sujeto pasivo efectuará la transmisión de sus Documentos Tributarios Electrónicos por las operaciones que realice.
3.2. Servicio de Transmisión para Eventos de Invalidación y Contingencia

Los servicios de transmisión para Eventos de Invalidación y Contingencia se encuentran descritos en el "Manual Técnico para la Integración Tecnológica del Sistema de Transmisión".
3.3. Autenticación

Para el uso de cada uno de los servicios del "Sistema de Transmisión DTE" se requiere de una autenticación previa del sujeto pasivo. El "Manual Técnico para la Integración Tecnológica del Sistema de Transmisión" contiene los detalles tecnológicos para el servicio de autenticación en dicho sistema.
3.4. Recepción de los DTE

La recepción de los DTE puede ser Uno a uno o en Lote. El "Manual Técnico para la Integración Tecnológica del Sistema de Transmisión" contiene los detalles tecnológicos para el servicio de recepción de los DTE.
3.5. Sello de Recepción

Consiste en un código otorgado por la Administración Tributaria que acredita el carácter de Documento Tributario Electrónico, conforme a lo dispuesto en el artículo 119-D inciso segundo del Código Tributario.

Dicho Sello se otorga a los documentos que han cumplido con las reglas establecidas en el punto 10. "Reglas para el otorgamiento del Sello de Recepción" de esta Normativa, es decir, con los requisitos y condiciones establecidas para la correcta generación, firma, transmisión y recepción de los mismos. En ese sentido, a partir de dicho otorgamiento los citados documentos podrán ser admisibles para amparar las deducciones fiscales.

Tiene como base un UUID Versión 4 y se le agregan caracteres alfanuméricos. Para su generación, no se utiliza información sensible del documento transmitido.

Ejemplo: 202179926FBFE844465396CA5B8913008732KCVY.
4. ENTREGA

Los DTE deberán entregarse a sus receptores en forma totalmente electrónica, con la misma información, estructura de datos y formato electrónico con que fueron generados, firmados y transmitidos a la Administración Tributaria. Debiendo contener el texto plano del documento generado conforme a la Estructura de Datos, el DTE firmado y el Sello de Recepción otorgado por la Administración Tributaria; dicho Archivo deberá nombrarse con el Código de Generación que le corresponda.


El archivo DTE es único en su formalidad y contenido, pudiendo ser reproducido con la misma integridad de datos y en tal sentido, tales reproducciones tendrán la misma originalidad que el inicialmente emitido, por lo tanto, podrán amparar las deducciones tributarias correspondientes siempre y cuando hayan obtenido el Sello de Recepción antes mencionado.

El medio de entrega deberá ser propicio para efectuarla, a través de los mecanismos de intercambio de datos determinados entre las partes.

Asimismo, los sujetos pasivos deberán entregar una versión interpretada y legible de dichos DTE, que cumpla con los requisitos dispuestos por la Administración Tributaria y que contenga un código QR (Quick Response) que enlace a la consulta de los DTE de la Administración Tributaria.
5. MÓDULOS

La plataforma tecnológica del sistema del sujeto pasivo emisor deberá poseer los siguientes módulos:
1) Generación: En este módulo se recopilará toda la información de la transacción ejecutada para ser procesada y consolidada como documento electrónico.
2) Firmado: Será el responsable de realizar el sellado/firmado de los documentos electrónicos de conformidad a la Ley de Firma Electrónica.
3) Transmisión: Comprende el medio que se encargará de transmitir el documento electrónico hacia los servicios de la plataforma de recepción de la Administración Tributaria expuestos para dicha finalidad.

El diseño de la arquitectura que soporte el funcionamiento del sistema deberá, según sea necesario de acuerdo al volumen de transacciones, contar con:
a) Plataforma de alta disponibilidad para garantizar la rapidez de los servicios de la misma de forma óptima.
b) Plataforma con un plan de recuperación ante desastres.
c) Utilización de balanceadores de carga.
e) Infraestructura auto escalable, para ajustar la utilización de recursos según el consumo de los servicios asociados a la plataforma.

6. SEGURIDAD

Cada sujeto pasivo establecerá su política de seguridad interna y es responsabilidad del mismo cerciorarse de que se cumplan para la correcta operatividad y transmisión de los documentos electrónicos.

Asimismo, el sistema de emisión de DTE debe contar con las debidas condiciones de seguridad y gestión de la plataforma, según sea necesario de acuerdo a sus políticas de seguridad y como requerimientos mínimos, deberá contar con:
a) Protección contra ataques externos.
b) Control de acceso no autorizado por terceros a los servicios/datos/software/hardware.
c) Registro y reporte detallado de accesos de usuarios y administradores por dirección IP origen.
e) Administración de registro o historial de procesos (logs), establecidos como condiciones generales y de requerimientos técnicos mínimos para el control.
Dentro de los lineamientos de seguridad asociados al documento, es importante mencionar dos aspectos claves, la firma electrónica del documento y el número de trazabilidad del mismo, este número de trazabilidad, que será el Código de Generación, permitirá identificar y asociar el detalle del documento en todo el ecosistema de documentos tributarios electrónicos tanto en los sistemas del sujeto pasivo como de la Administración Tributaria.

A nivel de seguridad de documento, los lineamientos técnicos para Documentos Tributarios Electrónicos de la Administración Tributaria, abarcan la utilización de los siguientes criterios:
- JWS para firma de documentos JSON, que permitirá garantizar que dicho documento ha permanecido inalterable desde su fuente al origen. Este firmado es adicional del
documento, se agrega junto con firma electrónica simple, bajo el estándar para transmisión y seguridad de documentos JSON, que es JWS.
- El estándar para el archivo JSON será ECMA-404, que es un lineamiento reconocido para manejo de información para el intercambio de datos bajo esta modalidad de archivo.
- UUIDv4 para trazabilidad de documentos.

7. FLUJO DE PROCESO DTE

![original image](https://cdn.mathpix.com/snip/images/IFCsYqNm1UrhEAkVaWfmk_5Z-1s679xu8rtOFmwO-es.original.fullsize.png)

ANEXO II
ESTRUCTURA DE DATOS DTE

\begin{tabular}{|l|l|l|l|l|l|l|l|l|l|l|}
\hline N° Campo & N° Sección & Campo JSON & Versión legible & Nombre del Campo & Descripción de contenido del campo & Condición del campo & Tipo de dato & Longitud/precisión & Especificación & Documentos que aplican \\
\hline \multicolumn{11}{|c|}{Sección 1: IDENTIFICACIÓN} \\
\hline 1 & 1 & identificacion.version & A & Versión & 
\begin{tabular}{l}
Se deberá ingresar el número de la versión del archivo JSON que se está trabajando, la cual debe asegurarse que sea la última versión vigente (sin punto, decimales ni cero a la izquierda). \\Se deberá ingresar valor 3 para los siguientes DTE: CCFE, NCE, NDE, NRE. \\ Se deberá ingresar valor 1 para los siguientes DTE: FE, CRE, DCLE, CLE, FSEE, FEXE, CDE.
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 2 Minimo: 1, Máximo: 2 & TC & TODOS \\
\hline 2 & 1 & identificacion.ambiente & C & Ambiente de destino & Deberá Ingresar el ambiente de trabajo por el cual se está transmitiendo el documento electrónico de acuerdo al catálogo CAT-001 Ambiente de Destino. & Requerido para su transmisión & Alfanumérico & Longitud: 2 Minimo: 2, Máximo: 2 & TC & TODOS \\
\hline 3 & 1 & identificacion.tipoDte & A & Tipo de Documento & Se deberá ingresar el código que corresponda al tipo del documento electrónico a emitir, de acuerdo a catálogo (CAT-002 Tipo de Documento). & Requerido para su transmisión & Alfanumérico & Longitud: 2 Mínimo: 2, Máximo: 2 & F & TODOS \\
\hline 4 & 1 & identificacion.numeroControl & A & Número de Control & \begin{tabular}{l}
Debe cumplir con la estructura definida por la Administración Tributaria con una longitud de 31 caracteres (las siglas DTE + código de tipo de documento +8 digitos alfanuméricos para describir código del establecimiento y código de punto de venta + un secuencial de 15 digitos). \\
Este número de control debe reiniciarse el 01 de enero; no debe repetirse en un año calendario.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 31 & F & TODOS \\
\hline 5 & 1 & identificacion.codigoGeneracion & A & Código de Generación & \begin{tabular}{l}
Debe cumplir con el estándar del UUID v4, el cual debe ser único por documento (no debe repetirse), longitud de 32 digitos separados por 4 guiones, haciendo un total de 36 posiciones dividido en 5 grupos. \\
El Código de Generación consiste en un número identificador único, aleatorio y universal. \\
Nota: Código de generación deberá incluir solamente letras mayúsculas.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 36 Minimo: 36, Máximo: 36 & F & TODOS \\
\hline 6 & 1 & identificacion.tipoModelo & A & Modelo de Facturación & Debe mostrar el código asignado al modelo de facturación que utilizará según catálogo. Ver catálogo: CAT-003 Modelo de Facturación. & Requerido para su transmisión & Numérico & Longitud: 1 & TC & TODOS \\
\hline 7 & 1 & identificacion.tipoOperacion & A & Tipo de Transmisión & \begin{tabular}{l}
Documentos: FE, CCFE, NRE, NCE, NDE, FEXE, FSEE. \\
Deberá contener el código de acuerdo al catálogo CAT-004 Tipo de Transmisión. \\
\\
Se ingresará el tipo de transmisión normal (código 1) en todos los DTE. \\
\\
Se permite el tipo de transmisión por contingencia (código 2) únicamente en contingencia para los siguientes documentos: FE, CCFE, NRE, NCE, NDE, FEXE, FSEE.
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 1 & TC & TODOS \\
\hline 8 & 1 & identificacion.tipoContingencia & C & Tipo de Contingencia & \begin{tabular}{l}
Deberá completarse este campo únicamente si se elije el tipo de transmisión con el Código 2 "Por Contingencia"; de lo contrario, cuando se utilice la transmisión normal deberá enviar este campo con valor null. \\
\\
Cuando se esté en contingencia, deberá contener el código de acuerdo a catálogo CAT-005 Tipo de Contingencia. \\
\\
Cuando el documento a generar sea CRE deberá enviar este campo con null. Campo de texto donde el contribuyente pueda ampliar el motivo de la Contingencia.
\end{tabular} & Requerido por tipo de operación (únicamente si tipo de transmisión es Contingencia) & Numérico|null & Longitud: 1 & TC & FE, CCFE, NCE, NDE, NRE, CRE, FEXE y FSEE \\
\hline 9 & 1 & identificacion.motivoContin & C & Motivo de Contingencia & \begin{tabular}{l}
Siempre que el campo "Tipo de Contingencia" se ingresa la opción 5-Otro. \\
\\
Si el documento electrónico no se está generando en contingencia deberá enviar este campo con null. \\
\\
Si en campo tipo de Contingencia se ingresa una opción diferente a 5, podrá enviar este campo con valor null. \\
\\
Cuando el documento a generar sea CRE deberá enviar este campo con null.
\end{tabular} & Requerido por tipo de operación (Cuando tipo Contingencia esté completo con la opción 5) & Alfanumérico null & Longitud: 500 Minimo:1 Máximo: 500 & TC & FE, CCFE, NCE, NDE, NRE, CRE, FEXE y FSEE \\
\hline 10 & 1 & identificacion.fecEmi & A & Fecha de Generación & La fecha de generación deberá tomarse del sistema de reloj del servidor al momento de generar el documento, cuya estructura definida por la Administración Tributaria es: AAAA-MM-DD. & Requerido para su transmisión & Alfanumérico & Longitud: 10 & F & TODOS \\
\hline 11 & 1 & identificacion.horEmi & A & Hora de Generación & La hora de generación deberá tomarse del sistema del contribuyente emisor en el momento de generar el documento, cuya estructura definida por la Administración Tributaria es: HH:MM:SS (Formato de 24 horas). & Requerido para su transmisión & Alfanumérico & Longitud: 8 & F & TODOS \\
\hline 12 & 1 & identificacion.tipoMoneda & C & Tipo de Moneda & Debe ser USD. & Requerido para su transmisión & Alfanumérico & Longitud: 3 & TC & TODOS \\
\hline \multicolumn{11}{|c|}{Sección 2: DOCUMENTOS RELACIONADOS} \\
\hline 16 & 2 & documentoRelacionado.fechaEmision & A & Fecha de Emisión del Documento Relacionado & \begin{tabular}{l}
CCFE, NRE, NCE, NDE, FE y FEXE. \\
\\
Deberá indicar la fecha en que fue generado el documento que se esté relacionando. Independientemente haya sido generado en formato electrónica o física, en formato YYYY-MM-DD. \\
\\
(CCFE, NRE y FE=Requerido por tipo de operación) \\
\\
Cuando no exista documento relacionado este campo deberá enviarse con valor null.
\end{tabular} & NCE y NDE = Requerido para su transmisión & Alfanumérico & Longitud: 10 & F & FE, CCFE, NRE, NCE, NDE \\
\hline \multicolumn{11}{|c|}{Sección 3: EMISOR} \\
\hline & 3 & & A & Emisor & Esta Sección contiene la información del emisor del DTE. Para el caso del CRE es Agente de Retención, para el CLE es el Comisionista, para el DCLE es el Agente perceptor, para la FEXE es el Exportador, para el CDE es el Donatario. & Requerido para su transmisión & Objeto & Longitud: 1 & & \\
\hline 17 & 3 & emisor.nit & A & NIT (Emisor) & Deberá contener el Número de NIT del emisor sin guiones. & Requerido para su transmisión & Alfanumérico & Longitud: 14 Minimo: 9 Máximo: 14 & F & FE, CCFE, NRE, NCE, NDE, CRE, CLE, DCLE, FEXE Y FSEE \\
\hline 18 & 3 & emisor.tipoDocumento & B & Tipo de documento de Identificación (Donatario) & Para efecto de CD únicamente se ingresará el código 36-NIT. & Requerido para su transmisión & Alfanumérico & 2 & TC & CDE \\
\hline 19 & 3 & emisor.numeroDocumento & A & Número de documento de Identificación (Donatario) & Deberá ingresar número Identificación tributaria del donatario. & Requerido para su transmisión & Alfanumérico & Longitud: 9 ó 14 & F & CDE \\
\hline 20 & 3 & emisor.nrc & A & NRC (Emisor) & \begin{tabular}{l}
(FSE = CCFE, CLE, CDE, FE y FEXE) \\
\\
Deberá contener el número de NRC del emisor sin guion. \\
\\
Nota: Cuando el NRC no posea ceros a la izquierda no deberá rellenar con ceros para cumplir con la longitud. \\
\\
(CRE = Requerido por tipo de operación) \\
\\
(FSEE y CDE = Opcional)
\end{tabular} & Requerido para su transmisión (CRE = Requerido por tipo de operación) & Alfanumérico & Longitud: 8 Minimo:2 máximo 8 & F & TODOS \\
\hline 21 & 3 & emisor.nombre & A & Nombre, denominación o razón social del contribuyente (Emisor) & Deberá contener el nombre, denominación o razón social del contribuyente emisor. & Requerido para su transmisión & Alfanumérico & Longitud: 250 Minimo: 1 Máximo: 250 & F & TODOS \\
\hline 22 & 3 & emisor.codActividad & C & Código de Actividad Económica (Emisor) & \begin{tabular}{l}
Deberá ingresar código que corresponda a cualesquiera de las actividades económicas registradas en el Registro Único de Contribuyentes (RUC). (ver catálogo: CAT-019 Actividades Económicas)
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 6 Minimo: 5 Máximo: 6 & TC & TODOS \\
\hline 23 & 3 & emisor.descActividad & A & Actividad Económica (Emisor) & \begin{tabular}{l}
Deberá ingresar nombre que corresponda a cualesquiera de las actividades económicas registradas en el Registro Único de Contribuyentes (RUC). (ver catálogo: CAT-019 Actividades Económicas)
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 150Minim o: 5Máximo: 150 & F & TODOS \\
\hline 24 & 3 & emisor.nombreComercial & C & Nombre Comercial (Emisor) & \begin{tabular}{l}
Podrá incorporar el nombre comercial del contribuyente emisor. \\
\\
Cuando no aplique deberá llenar el campo con null.
\end{tabular} & Opcional & Alfanumérico & Longitud: 150 Minimo: 1 Máximo: 150 & TC & FE, CCFE, NRE, NDE, NRE, CRE, CLE, DCLE, FEXE Y FSEE \\
\hline 25 & 3 & emisor.tipoEstablecimiento & A & Tipo de establecimiento (Emisor) & \begin{tabular}{l}
Deberá indicarse el tipo de establecimiento en el que se genera el documento electrónico según catálogo CAT-009 Tipo de Establecimiento.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 2 & F & FE, CCFE, NCE, NDE, NRE, CRE, CLE, DCLE, FEXE Y CDE \\
\hline 26 & 3 & emisor.direccion.departamento & A & Dirección Departamento (Emisor) & \begin{tabular}{l}
Deberá indicar el código de Departamento en el cual se encuentra ubicada la casa matriz, sucursal, agencia, bodega, patio, predio, otro; donde se ha realizado la operación (ver catálogo CAT-012 Departamento).
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 2 & F & TODOS \\
\hline 27 & 3 & emisor.direccion.municipio & A & Dirección Municipio (Emisor) & \begin{tabular}{l}
Deberá indicar el código del Municipio donde se encuentra ubicada la casa matriz, sucursal, agencia, bodega, patio, predio, donde se ha realizado la operación (ver catálogo CAT-013 Municipio).
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 2 & F & TODOS \\
\hline 28 & 3 & emisor.direccion.complemento & A & Dirección complemento (Emisor) & \begin{tabular}{l}
Deberá detallar el complemento de la dirección de la casa matriz, sucursal, agencia, bodega, patio, predio u otro donde se ha realizado la operación.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 200 Minimo: 1 Máximo: 200 & F & TODOS \\
\hline 29 & 3 & emisor.telefono & A & Teléfono (Emisor) & \begin{tabular}{l}
Deberá incorporar el número de teléfono del emisor, se podrán ingresar hasta un máximo de 8 números telefónicos separados por comas.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 30 Minimo:8 Máximo: 30 & TC & TODOS \\
\hline 30 & 3 & emisor.correo & A & Correo electrónico (Emisor) & Deberá incorporar el correo electrónico del emisor con dominio vigente. & Requerido para su transmisión & Alfanumérico & Longitud: máxima: 100 & TC & TODOS \\
\hline 31 & 3 & emisor.codEstableMH & C & Código del establecimiento asignado por el MH & \begin{tabular}{l}
Podrá ingresar el código de Casa matriz / Sucursal / Agencia / Bodega / Predio / Otro que la Administración Tributaria le asigne. \\
\\
Nota: Por el momento, durante la transición deberá enviarlo con null.
\end{tabular} & Opcional & Alfanumérico / null & Longitud: 4 Máximo: 4 Minimo: 4 & TC & FE, CCFE, NRE, CRE, CLE, DCLE, FEXE, FSEE Y CDE \\
\hline 32 & 3 & emisor.codEstablePorContribuyente & C & Código del establecimiento asignado por el contribuyente & \begin{tabular}{l}
Podrá re incorporar el código casa matriz / Sucursal / Agencia / Bodega / Predio / Otro que el contribuyente posea internamente. \\
\\
Cuando no posea código interno deberá enviarlo con null.
\end{tabular} & Opcional & Alfanumérico / null & Longitud: 4 Máximo: 4 Minimo: 4 & TC & FE, CCFE, NRE, CRE, CLE, DCLE, FEXE, FSEE y CDE \\
\hline 33 & 3 & emisor.codPuntoVentaMH & C & Código del Punto de Venta (Emisor) Asignado por el MH & \begin{tabular}{l}
Podrá incorporar el código asignado por la Administración Tributaria para el punto de venta donde se genera el documento electrónico. Este código será informado cuando la Administración Tributaria lo asigne. \\
\\
Nota: Por el momento, deberá enviar con null.
\end{tabular} & Opcional & Alfanumérico / null & Longitud: 4 & TC & FE, CCFE, NRE, CRE, CLE, DCLE, FEXE, FSEE Y CDE \\
\hline 34 & 3 & emisor.codPuntoVentaPorContribuyente & C & Código del Punto de Venta (Emisor) Asignado por el contribuyente & \begin{tabular}{l}
Podrá incorporar el código del punto de venta donde se genera el documento electrónico que el emisor lleva internamente. \\
\\
Cuando el emisor no posea código de punto de venta este campo se completará con null.
\end{tabular} & Opcional & Alfanumérico/ null & Longitud: 15 Minimo: 1 Máximo: 15 & TC & FE, CCFE, NRE, CRE, CLE, DCLE, FEXE, FSEE Y CDE \\
\hline 35 & 3 & emisor.tipoItemExpor & C & Tipo de ítem & \begin{tabular}{l}
Deberá seleccionar qué tipo de ítem está exportando (ver catálogo CAT-011 Tipo de ítem). \\
\\
Nota: Este campo solo permitirá opciones 1 o 2 y 3.
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 1 & TC & FEXE \\
\hline 36 & 3 & emisor.recintoFiscal & B & Recinto fiscal & \begin{tabular}{l}
Cuando en campo "Tipo de ítem" se ingresen las opciones 1 ó 3, deberá indicar el recinto fiscal de la operación (ver catálogo CAT-022 Recinto fiscal). \\
\\
Este campo será null cuando en campo "tipo de ítem" se ingresa la opción 2.
\end{tabular} & Requerido por tipo de operación & Alfanumérico/ null & Longitud: 2 & TC & FEXE \\
\hline 37 & 3 & emisor.regimenExportacion & B & Régimen de exportación & \begin{tabular}{l}
Cuando en campo "Tipo de ítem" se ingresen las opciones 1 ó 3 deberá ingresar el régimen de exportación a que se somete la mercadería, utilizando el catálogo "CAT 028- Régimen". \\
\\
Este campo será null cuando en campo "Tipo de ítem" se ingresa la opción 2.
\end{tabular} & Requerido por tipo de operación & Alfanumérico/ null & Longitud: 13 & TC & FEXE \\
\hline \multicolumn{11}{|c|}{Sección 4: RECEPTOR} \\
\hline & 4 & & A & Receptor & \begin{tabular}{l}
Contiene la información del receptor del DTE. \\
\\
Para el caso del CRE, el receptor es el Sujeto de Retención; para el CLE, es el Mandante; para el DCLE, es el Afiliado; para el FSEE, es el Sujeto Excluido; para el CDE, es el Donante.
\end{tabular} & Requerido & Objeto & Longitud: 1 & & \\
\hline 38 & 4 & receptor.tipoDocumento & A (FE = XE - C) & Tipo de documento de Identificación (Receptor) & \begin{tabular}{l}
Deberá seleccionar codificación de acuerdo a catálogo de tipo de documento de identificación (Receptor). Ver catálogo CAT-024 Tipo de documento del receptor. \\
\\
Nota: Se ingresará la opción 13-DUI para el caso de las personas naturales no inscritas en IVA.
\end{tabular} & Requerido para su transmisión (FE = Requerido por tipo de operación) & Alfanumérico & Longitud: 2 & F/T C & FE, NRE, CRE, FEXE, FSEE y CDE \\
\hline 39 & 4 & receptor.numeroDocumento & A & Número de documento de Identificación (Receptor) & Deberá ingresar número de documento de identificación del Receptor. & Requerido para su transmisión (FE = Requerido por tipo de operación) & Alfanumérico & Longitud: 30 Minimo: 9 Máximo: 30 & F/T C & FE, NRE, CRE, FEXE, FSEE y CDE \\
\hline 40 & 4 & receptor.nit & A & NIT (Receptor) & Deberá de contener el NIT del receptor sin guiones. & Requerido para su transmisión & Alfanumérico & Longitud: 14 Minimo: 9 Máximo: 14 & F & CCFE, NCE, NDE, CLE y DCLE \\
\hline 41 & 4 & receptor.nrc & A (NRE, CRE y DCLE = FE - (CD E= C) & NRC (Receptor) & \begin{tabular}{l}
Deberá de contener el número de NRC del receptor sin guion, según el Registro Único de Contribuyentes. \\
\\
Nota: Cuando el NRC no posea ceros a la izquierda no deberá rellenar con ceros para cumplir con la longitud. \\
\\
(FE y CDE = Opcional)
\end{tabular} & Requerido para su transmisión (NRE, CRE y DCLE = Requerido por tipo de operación) & Alfanumérico & Longitud: 8 Minimo 2 máximo 8 & F & FE, CCFE, NCE, NDE, NRE, CRE, CLE, DCLE, y CDE \\
\hline 42 & 4 & receptor.nombre & A & Nombre, denominación o razón social del contribuyente (Receptor) & \begin{tabular}{l}
Deberá contener el nombre, denominación o razón social del contribuyente receptor.
\end{tabular} & Requerido para su transmisión (FE = Requerido por tipo de operación) & Alfanumérico & Longitud: 250 Minimo: 1 Máximo: 250 & F & TODOS \\
\hline 43 & 4 & receptor.codActividad & C & Código de Actividad Económica (Receptor) & \begin{tabular}{l}
El contribuyente deberá incorporar el código de la actividad económica registrada (primaria, secundaria o terciaria) de acuerdo a NRC (ver catálogo: CAT-019 Actividades Económicas). \\
\\
(FE y FSEE = opcional)
\end{tabular} & Requerido para su transmisión (CRE y CDE = Requerido por tipo de operación) & Alfanumérico & Longitud: 6 Minimo: 5 Máximo: 6 & TC & FE, CCFE, NCE, NDE, NRE, CRE, CLE, DCLE, FSEE Y CDE \\
\hline 44 & 4 & receptor.descActividad & A (FE y CDE = C) (FSEE = B) & Actividad Económica (Receptor) & \begin{tabular}{l}
El contribuyente deberá incorporar la actividad económica registrada (primaria, secundaria o terciaria) de acuerdo a NRC (ver catálogo: CAT-019 Actividades Económicas).
\end{tabular} & Requerido para su transmisión (CRE = Requerido por tipo de operación) (FE = opcional) & Alfanumérico & Longitud: 150 Minimo: o. 5 Máximo: 150 & F & TODOS \\
\hline 45 & 4 & receptor.nombreComercial & C & Nombre Comercial (Receptor) & \begin{tabular}{l}
Podrá incorporar nombre comercial del contribuyente receptor, de lo contrario deberá enviarlo con valor null.
\end{tabular} & Opcional / null & Alfanumérico & Longitud: 150 Minimo: 1 Máximo: 150 & TC & FE, CCFE, NRE, NCE, NDE, NRE, CRE, CLE, DCLE, FEXE \\
\hline 46 & 4 & receptor.tipoEstablecimiento & A & Tipo de establecimiento (Receptor) & \begin{tabular}{l}
Campo requerido, únicamente aceptará codificación según catálogo CAT-009 Tipo de Establecimiento.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 2 & TC & DCL \\
\hline 47 & 4 & receptor.direccion.departamento & A (FE = C) (CD E = B) & Dirección: Departamento (Receptor) & \begin{tabular}{l}
Deberá indicar el código del Departamento donde se encuentra ubicada la dirección del receptor (ver catálogo CAT-012 Departamento). \\
\\
(FE = opcional)
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 2 Minimo: 2 Máximo: 2 & F & FE, CCFE, NRE, NCE, NDE, CRE, CLE, DCLE, FSEE y CDE \\
\hline 48 & 4 & receptor.direccion.municipio & A (FE = C) (CD E = B) & Dirección: Municipio (Receptor) & \begin{tabular}{l}
Deberá indicar el Municipio en el cual se encuentra ubicada la dirección del receptor (ver catálogo CAT-013 Municipio). \\
\\
(FE = opcional)
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 2 Minimo: 2 Máximo: 2 & F & FE, CCFE, NRE, NCE, NDE, CRE, CLE, DCLE, FSEE y CDE \\
\hline 49 & 4 & receptor.direccion.complemento & A (FE = C) (CD E = B) & Dirección: complemento (Receptor) & \begin{tabular}{l}
Deberá detallar el complemento de la dirección geográfica completa del receptor. \\
\\
(FE = opcional)
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 200 Minimo: 1 Máximo: 200 & F & TODOS \\
\hline 50 & 4 & receptor.codPais & C & Código de país destino de exportación (Receptor) & \begin{tabular}{l}
Deberá ingresar el país destino más efectivo de la exportación o de la nacionalidad del donante (ver catálogo CAT-020 País). \\
\\
País destino de Exportación para FEXE. \\
Nacionalidad del Donante para CDE.
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 4 Mínimo: 4 Máximo: 4 & TC & FEXE y CDE \\
\hline 51 & 4 & receptor.nombrePais & C & País destino de exportación (Receptor) & \begin{tabular}{l}
Deberá ingresar el país destino de la mercadería (ver catálogo CAT-020 País).
\end{tabular} & Requerido para su transmisión & Alfabético & Longitud: 50 Mínimo: 3 Máximo: 50 & TC & FEXE \\
\hline 52 & 4 & receptor.codDomicilio & C & Domicilio (Receptor) & \begin{tabular}{l}
Deberá ingresar codificación de acuerdo a catálogo CAT-032 Domicilio Fiscal.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 1 & TC & CDE \\
\hline 53 & 4 & receptor.codEstableMH & C & Código del establecimiento asignado por el MH & \begin{tabular}{l}
Podrá incorporar el código del establecimiento del contribuyente receptor donde se genera el DTE. \\
\\
Este código el MH lo asignará, cuando la Administración Tributaria lo asigne, por el momento deberá enviar este campo con null.
\end{tabular} & Opcional & Alfanumérico & Longitud: 4 Mínimo: 4 Máximo: 4 & TC & DCLE \\
\hline 54 & 4 & receptor.codPuntoVenta & C & Código del Punto de Venta (Receptor) & \begin{tabular}{l}
Podrá incorporar el código del punto de venta asignado al contribuyente receptor donde se genera el DTE. \\
\\
Este código será informado Cuando la Administración Tributaria lo asigne, por el momento deberá enviar este campo con null.
\end{tabular} & Opcional & Alfanumérico & Longitud: 4 & TC & DCLE \\
\hline 55 & 4 & receptor.tieneritulo & A & Bienes entregados a Título de & \begin{tabular}{l}
Deberá ingresar el código en qué son entregados los bienes de acuerdo a catálogo CAT-014 Tipo de Entrega de los bienes.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 1 & F & NRE \\
\hline 56 & 4 & receptor.tipoPersona & C & Tipo de Receptor & \begin{tabular}{l}
Deberá clasificar el tipo de receptor sea persona jurídica o persona natural (ver catálogo CAT-029 Tipo de receptor).
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 1 & TC & FEXE \\
\hline 57 & 4 & receptor.telefono & C A (FE = XE - C) (FSE E = B) & Teléfono (Receptor) & \begin{tabular}{l}
Deberá ingresar número de teléfono del receptor, se podrá ingresar hasta un máximo de 3 números telefónicos separados por comas.
\end{tabular} & Opcional & Alfanumérico & Longitud: 30 Mínimo: 8 Máximo: 30 & TC & TODOS \\
\hline 58 & 4 & receptor.correo & A (FE = XE - C) (FSE E = B) & Correo electrónico (Receptor) & \begin{tabular}{l}
Deberá incorporar el correo electrónico con dominio vigente del contribuyente receptor.
\end{tabular} & Requerido para su transmisión (FE, CRE, FSEE y CDE = opcional) & Alfanumérico & Longitud: máxima de 100 & TC & TODOS \\
\hline \multicolumn{11}{|c|}{Sección 5: DOCUMENTOS ASOCIADOS} \\
\hline & 5 & & B(D) & Documentos asociados & \begin{tabular}{l}
En estos campos se describen los documentos asociados. \\
\\
Se podrán describir hasta 20 documentos asociados, excepto para la FEXE, donde se podrán describir desde 1 hasta 20 documentos. \\
\\
Cuando no se requieran, deberá enviar esta sección con null. \\
\\
Cuando aplique, si el campo "Documento asociado" está completo con la opción 1 "Factura", la información deberá completarse desde el campo "Número de generación" hasta el campo "Descripción de documento asociado". \\
\\
Cuando aplique, si el campo "Documento asociado" está completo con la opción 3 "Médico", deberá completarse desde el campo "Nombre del médico que presta el Servicio" hasta el campo "Código del tipo de Servicio realizado". \\
\\
En la FEXE, cuando el campo "Documento asociado" esté completo con la opción 2 "Transporte", deberá completar desde el campo "Modo de transporte" hasta el campo "Nombre y apellido del conductor". \\
\\
En esta Sección para el CDE, será obligatorio como mínimo ingresar los datos del documento de la resolución del donatario.
\end{tabular} & Requerido para su transmisión = Requerido por tipo de operación & Arreglo de objeto / null & Longitud: 10(FEXE = 20) & & \\
\hline 59 & 5 & otroDocumento.codDocAsociado & C & Documento asociado & \begin{tabular}{l}
Este campo es el documento asociado que corresponde al emisor, al receptor, al médico o a transporte según catálogo CAT-025 Tipo de documento asociado. \\
\\
Cuando no existan documentos asociados deberá enviar este campo con null. \\
\\
Puede describir el nombre del tipo de documento asociado al que hace referencia (por ejemplo: Resoluciones, Licencias, Permisos, Contratos, Carta de Venta, entre Otros).
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 1 & TC & FE, CCFE, FEXE y CDE \\
\hline 60 & 5 & otroDocumento.descDocumento & B & Identificación del documento asociado & \begin{tabular}{l}
Aplica cuando el campo "documento asociado" esté descrito con la opción 1 o 2. \\
\\
Para el CDE será obligatorio como mínimo ingresar los datos de la resolución de sujeto excluido del donatario.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 100 & TC & FE, CCFE, FEXE y CDE \\
\hline 61 & 5 & otroDocumento.detalleDocumento & B & Descripción de documento asociado & \begin{tabular}{l}
Cuando no existan documentos asociados o cuando el campo "documento asociado" esté descrito con la opción 3 "médico" y 4 "transporte", este campo deberá enviarse con null. \\
\\
Deberá describir los datos importantes del tipo de documento asociado (ejemplo: el número de resolución, fechas, número de contrato). \\
\\
Aplica cuando el campo "documento asociado" esté descrito con la opción 1 o 2. \\
\\
Deberá enviarse con null. \\
\\
a) En caso no existan documentos asociados. \\
\\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente de 1 o 2.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 300 & TC & FE, CCFE, FEXE y CDE \\
\hline 62 & 5 & otroDocumento.medico.nombre & C & Nombre de médico que presta el Servicio & \begin{tabular}{l}
Este campo deberá completarse si en el campo "Documento asociado" se ha llenado con la opción 3 "médico". \\
\\
Cuando aplique, deberá detallar el nombre del médico que presta el servicio. \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente a 3.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: máxima 100 & TC & FE y CCFE \\
\hline 63 & 5 & otroDocumento.medico.nit & C & NIT de médico que presta el Servicio & \begin{tabular}{l}
Este campo deberá completarse si el campo "Documento asociado" se ha llenado con la opción 3 "médico". \\
\\
Cuando aplique, deberá detallar el NIT del médico que presta el servicio. El NIT debe ingresarse sin guiones. \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente a 3.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 14 Mínimo: 9Máximo: 14 & TC & FE y CCFE \\
\hline 64 & 5 & otroDocumento.medico.docIdentificacion & C & Documento de identificación del médico no domiciliado & \begin{tabular}{l}
Este campo deberá completarse si el campo "Documento asociado" se ha llenado con la opción 3 "médico". \\
\\
Cuando aplique, deberá detallar el documento con el que se identifica al médico no domiciliado. \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente a 3. \\
c) Si el médico que presta el servicio se identifica con NIT.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: máxima 25 & TC & FE y CCFE \\
\hline 65 & 5 & otroDocumento.medico.tipoServicio & C & Código del Servicio Realizado & \begin{tabular}{l}
Este campo deberá completarse si el campo "Documento asociado" se ha llenado con la opción 3 "médico". \\
\\
Cuando aplique, deberá detallar el Código según el catálogo CAT-017 Código del Servicio Realizado. \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente a 3.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 1 & TC & FE y CCFE \\
\hline 66 & 5 & otroDocumento.modTransp & B & Modo de transporte & \begin{tabular}{l}
Este campo deberá completarse si en el campo "Documento asociado" se ha elegido la opción 4 "Transporte. \\
\\
Cuando aplique, deberá detallar el transporte utilizado en la exportación según el catálogo CAT-030 "Modo de transporte" \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente de 4.
\end{tabular} & Requerido por tipo de operación & Numérico / null & Longitud: 11 & TC & FEXE \\
\hline 67 & 5 & otroDocumento.placaTrans & B & Número de Identificación de transporte & \begin{tabular}{l}
Este campo deberá completarse si en el campo "Documento asociado" se ha elegido la opción 4 "Transporte. \\
\\
Cuando aplique, deberá ingresar de identificación del medio de transporte utilizado en la exportación. \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente de 4.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 70 Mínimo: 1Máxima: 70 & TC & FEXE \\
\hline 68 & 5 & otroDocumento.numConductor & C & N° de Identificación del Conductor & \begin{tabular}{l}
Este campo deberá completarse si en el campo "Documento asociado" se ha elegido la opción 4 "Transporte. \\
\\
Se deberá ingresar el número de identificación del conductor del transporte. \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente a 4.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 100 Mínimo: 5 Máxima: 100 & TC & FEXE \\
\hline 69 & 5 & otroDocumento.nombreConductor & C & Nombre y apellidos del conductor & \begin{tabular}{l}
Este campo deberá completarse si en el campo "Documento asociado" se ha elegido la opción 4 "Transporte. \\
\\
Se deberá escribir el nombre y apellidos del conductor del medio de transporte. \\
\\
Deberá enviarse con null: \\
a) En caso no existan documentos asociados. \\
b) Cuando el campo "Documento asociado" esté descrito con una opción diferente a 4.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 100 Mínimo: 5 Máxima: 200 & TC & FEXE \\
\hline \multicolumn{11}{|c|}{Sección 6: VENTAS POR CUENTA DE TERCEROS} \\
\hline & 6 & & B(D) & Ventas por cuenta de terceros & \begin{tabular}{l}
Esta sección deberá completarse cuando la venta es por cuenta de terceros, de lo contrario, se completará con null. \\
\\
Importante: Si los documentos (FE, CCFE, NCE, NDE, FEXE) son emitidos por cuenta de terceros deberá completarse la información de los DTE emitidos por cuenta de terceros.
\end{tabular} & Requerido por tipo de operación & Objeto / null & Longitud:1 & & \\
\hline 70 & 6 & ventaTercero.nit & B & NIT por cuenta de Terceros & \begin{tabular}{l}
Deberá contener el NIT del tercero sumado la venta por cuenta de terceros. \\
\\
NIT deberá ingresarse sin guiones. \\
\\
Nota: Cuando las ventas no se realicen por cuenta de terceros deberá enviar este campo con null.
\end{tabular} & Requerido por tipo de operación & Alfanumérico & Longitud: 14 Mínimo: 9 Máximo: 14 & F & FE, CCFE, NRE, NCE, NDE, FEXE \\
\hline 71 & 6 & ventaTercero.nombre & B & Nombre, denominación o razón social del tercero & \begin{tabular}{l}
Deberá indicar el nombre, denominación o razón social del tercero, cuando se realice una venta por cuenta de terceros. \\
\\
Nota: Cuando las ventas no se realicen por cuenta de terceros deberá enviar campo con null.
\end{tabular} & Requerido por tipo de operación & Alfanumérico & Longitud: 250 Mínimo: 1 Máximo: 250 & = & FE, CCFE, NRE, NCE, NDE, FEXE \\
\hline \multicolumn{11}{|c|}{Sección 7: CUERPO DEL DOCUMENTO} \\
\hline & 7 &  & A & Cuerpo del Documento & \begin{tabular}{l}
En esta seccion contiene la informacion detallada de la operación realizada cada uno de los documentos \\
\\
En los campos numéricos que reflejen valores monetarios en los DTE, se permitirá hasta ocho posiciones decimales, (fraccionaria); en consecuencia, en los casos que se utilice más de 8 decimales cuando la novena posición decimal de estos campos sea igual o mayor a 5, la octava posición decimal se deberá redondear 1 hacia arriba.
\end{tabular} & Requerido para su transmisión & Arreglo de objeto (DCL=Objeto) & 2000 (CRE y CL= 500) & \\
\hline 72 & 7 & cuerpoDocumento.numItem & A & N° de ítem & \begin{tabular}{l}
En este campo se hará referencia a las filas de los ítems del cual se está realizando en cada uno de los documentos.
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 4 & TC & FE, CCFE, NRE, NCE, NDE, CRE, CLE, FEXE, FSEE y CDE \\
\hline 73 & 7 & cuerpoDocumento.tipoItem & A & Tipo de ítem & \begin{tabular}{l}
Deberá indicar el tipo de ítem de la operación que se está realizando, según catálogo CAT- 01 Tipo de ítem \\
\\
Notas: \\
1. Se deberá ingresar en este campo la opción 4, cuando se detallen impuestos cuyo valor está sujeto al cálculo del IVA, es decir, que se detalle en el ítem impuestos que correspondan a los códigos A8, 57, D4, D5, A6, contenidos en catálogo CAT-015 Tributos, apartado 2 \\
\\
2. En FSEE no se permite el uso del código 4 - Otros tributos
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 1 & TC & FE, CCFE, NRE, NCE, NDE, FSEE \\
\hline 74 & 7 & cuerpoDocumento.tipoDonacion & A & Tipo donación & Deberá indicar el tipo de donación que se está realizando, según catálogo: CAT-025 "Tipo de donación" & Requerido para su transmisión & Alfanumérico & Longitud: 2 & TC & CDE \\
\hline 75 & 7 & cuerpoDocumento.depreciacion & A & Depreciación & \begin{tabular}{l}
Consiste en tipo de bien \\
Completo con la opción 2 (Bien), deberá ingresar el valor de la depreciación del bien donado. \\
\\
Cuando no tenga efecto la depreciación en los bienes donados, así como otros tipos de donación o servicios, deberá completar el campo con \$0.00 \\
\\
Permite un máximo de 11 posiciones en el valor entero \\
\\
Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero
\end{tabular} & Requerido por tipo de operación & Numérico & 11,8 & TC & CDE \\
\hline 76 & 7 & cuerpo Docum ento.tip oDte & A & Tipo de Documento Tributario Relacionado & \begin{tabular}{l}
Se deberá indicar el código del documento relacionado según catálogo CAT-002 "Tipo de Documento" . \\
Este campo podrá repetirse hasta un máximo de 500 veces (indicando el tipo de documento que se está detallando en cada ítem). \\
Notas: \\
a) Se permitirá relacionar documentos emitidos de forma física y electrónica de manera conjunta o separada. \\
b) En el CRE no se podrán integrar diferentes tipos de documentos (es decir un CCFE con una FE). \\
c) En el CLE se permitirá relacionar documentos de diferentes tipos. Por ejemplo: En un mismo CLE podrán relacionarse: CCF, F, FEX, NC y ND.
\end{tabular} & Requerido para su transmisión & Alfanumérico & Longitud: 2 & F & CRE y CLE \\
\hline 77 & 7 & cuerpo Docum ento.tip oDoc & C & Tipo de generación del documento & \begin{tabular}{l}
Se seleccionará el tipo de generación del documento según catálogo CAT-007 "Tipo de Generación". \\
Este campo podrá repetirse hasta un máximo de 500 veces.
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 1 & TC & CRE y CLE \\
\hline 78 & 7 & cuerpo Docum ento.nu meroDo cument o & C (CR Ey CLE =A) & Número de documento relacionado & \begin{tabular}{l}
Cuando aplique deberá ingresar el código de generación o número correlativo del documento que se está referenciando. \\
Notas: \\
1. En el caso de CCFE, NRE, NCE, NDE, sólo se podrá ingresar los números de documentos relacionados que se encuentren descritos en la sección de documentos relacionados. Asimismo, este campo podrá repetirse un máximo de 2000 veces, debiendo ingresarse el número del documento relacionado en cada uno de los ítems, pudiendo relacionarse desde 1 hasta 50 documentos. \\
2. Para el CLE se permitirá el ingreso del código de generación o número correlativo del documento una sola vez con un mismo estado. Asimismo, ninguno de los documentos informados en un CLE (F, CCF, NC, ND, FEX) podrá ser ingresado en otro CLE generado con posterioridad, es decir, sólo se podrá relacionar una vez un documento activo a un CLE. \\
3. Para CRE y CLE este campo podrá repetirse un máximo de 500 veces,
debiendo ingresar un documento relacionado por cada item.
\end{tabular} & \begin{tabular}{l}
CLE = Requerido para su transmisión \\
(Requerido por tipo de operación)
\end{tabular} & Alfanumérico & \begin{tabular}{l}
Longitud 36 \\
Mínimo 1 máximo 36
\end{tabular} & F & FE, CCFE, NRE, NCE, NDE, CRE, CLE \\
\hline 79 & 7 & cuerpo Docum ento.fec haEmisi on & A & Fecha de generación del documento relacionado & Deberá ingresar la fecha de generación del documento relacionado. La estructura definida por la Administración Tributaria es: YYYY-MM-DD. & Requerido para su transmisión & Alfanumérico & Longitud: 10 & F & CRE y CLE \\
\hline 80 & 7 & cuerpo Docum ento.ca ntidad & A & Cantidad & \begin{tabular}{l}
Deberá indicar la cantidad del producto o servicio que detalla por ítem. \\
Este campo se deberá completar con valor 1 en los siguientes casos: \\
a) Cuando se haga uso del campo "Cargos / Abonos que no afectan la base imponible". \\
b) Cuando campo "Tipo de item" esté llenado con la opción 4. \\
Permite un máximo de 11 posiciones en el valor entero. Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero.
\end{tabular} & Requerido para su transmisión & Numérico & 11,8 & F & FE, CCFE, NRE, NCE, NDE, FEXE, FSEE y CDE. \\
\hline 81 & 7 & cuerpo Docum ento.co digo & C & Código & \begin{tabular}{l}
Este campo podrá contener la codificación con la que el Emisor identifica sus productos o servicios. \\
Este campo podrá ser enviado con null en los siguientes casos: \\
a) El Emisor no cuenta con dicha codificación. \\
b) Cuando se haga uso del campo "Cargos / Abonos que no afectan la base imponible". \\
c) Cuando el campo "Tipo de ítem" esté llenado con la opción 4.
\end{tabular} & Opcional & Alfanumérico & \begin{tabular}{l}
Longitud: 25 \\
Mínimo: 1 Máximo: 25
\end{tabular} & TC & FE, CCFE, NRE, NCE, NDE, FEXE, FSEE y CDE. \\
\hline 82 & 7 & cuerpo Docum ento.co dTribut o & C & Tributo sujeto a cálculo de IVA & \begin{tabular}{l}
Apartado especial para otros impuestos detallados en el cuerpo del documento sujetos al IVA. \\
Campo especial para el uso de la sección 2 del CAT-015 "tributos" (códigos A8, 57. 90, D4, D5, A6). \\
Será requerido cuando en el campo "Tipo de ítem" se ingrese la opción 4 (si el campo "Tipo de ítem" tiene una opción diferente, deberá enviar con null). \\
Notas: \\
1. Cuando se haga uso de este campo, el valor calculado del impuesto deberá ingresarse en el campo ventas gravadas (ingresando en el campo "cantidad" el valor 1 y en el campo "precio unitario" el valor calculado del tributo). \\
2. Cuando se haga uso de este campo para CCFE, NRE, NCE y NDE se permitirá únicamente el código 20-IVA en el campo "Código del Tributo". No se permitirá adicionar otros códigos. \\
3. Cuando se haga uso de este campo para FE el campo "Código del Tributo "se deberá enviar con null.
\end{tabular} & Requerido por tipo de operación & Alfanumérico / null & Longitud: 5 & TC & FE, CCFE, NRE, NCE, NDE \\
\hline 83 & 7 & cuerpo Docum ento.uni Medida & A & Unidad de Medida & \begin{tabular}{l}
Deberá detallar el código de la unidad de medida que utiliza para la descripción del producto por ítem (Ver catálogo CAT-014 "unidad de medida") \\
Se deberá ingresar la opción 99 (otra) de dicho catálogo cuando: \\
a) El contribuyente preste un servicio. b) No aplique unidad de medida o la unidad de medida no esté contemplada dentro del catálogo proporcionado. c) Se haga uso del campo "Cargos / Abonos que no afectan la base imponible". \\
d) El campo "Tipo de ítem" esté lleno con la opción 4.
\end{tabular} & Requerido para su transmisión & Numérico & Longitud: 2 & F & FE, CCFE, NRE, NCE, NDE, FEXE, CDE y FSEE \\
\hline 84 & 7 & cuerpo Docum ento.de scripció n & A (CR E = C) & Descripción & Deberá contener la descripción por ítem que detalle el producto y/o servicio de la operación. & Requerido para su transmisión (CRE= opcional) & Alfanumérico & Longitud: 1000 Mínimo: 1 Máximo: 1000 & F & FE, CCFE, NCE, NDE, NRE, CRE, FEXE, FSEE y CDE \\
\hline 85 & 7 & cuerpo Docum ento.pre cioUni & A & Precio Unitario & \begin{tabular}{l}
Deberá indicar por ítem el precio unitario de cada producto o servicio de la operación.Permite un máximo de 11 posiciones en el valor entero. Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero. \\
Condiciones especiales: \\
a) Cuando se haga uso del campo "Cargos / Abonos que no afectan la base imponible", deberá ingresarse el valor \$0.00. \\
b) Cuando el campo "Tipo de ítem" se complete con la opción 4 deberá reflejarse el valor calculado del tributo sujeto a IVA.
\end{tabular} & Requerido para su transmisión & Numérico & 11,8 & F & FE, CCFE, NRE, NCE, NDE, FEXE y FSEE \\
\hline 86 & 7 & cuerpo Docum ento.Val orUni & A & Valor Unitario & \begin{tabular}{l}
Deberá indicar el costo unitario de los bienes o servicios donados. \\
Nota: Cuando la donación sea en efectivo, deberá ingresar el monto total de la donación.
\end{tabular} & Requerido para su transmisión & Numérico & 11,8 & F & CDE \\
\hline 87 & 7 & cuerpo Docum ento.m ontoDe scu & A & Descuento, Bonificación , Rebajas por item & \begin{tabular}{l}
En este campo se detallarán por Ítem los descuentos, bonificaciones o rebajas realizadas a los productos o servicios. \\
Permite un máximo de 11 posiciones en el valor entero. Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero. \\
Cuando no aplique el descuento deberá ingresar el valor \$0.00
\end{tabular} & Requerido para su transmisión & Numérico & 11,8 & TC & FE, CCFE, NRE, NCE, NDE, FEXE, FSEE \\
\hline 88 & 7 & cuerpo Docum ento.ve ntaNoS uj & A & Ventas No Sujetas & \begin{tabular}{l}
Deberá detallar el valor de las ventas no sujetas de la operación, las cuales están dadas por el resultado de: [(precio unitario * cantidad) - " Descuento, Bonificación, Rebajas por item"] \\
Si no existen ventas no sujetas deberá ingresar \$0.00 \\
Permite un máximo de 11 posiciones en el valor entero. Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero. \\
Se dará holgura de \$ 0.01 ctvs. Hacia arriba y hacia abajo por diferencias entre los cálculos en el sistema del contribuyente y la aplicación de fórmula para validación del cálculo de la A.T. \\
Nota: Para el CLE, será el resultado de restar al "Total de operaciones Ventas no sujetas" - el "Monto global de Descuento, Bonificación, Rebajas y otros a Ventas no sujetas" contenidos en el documento que se está liquidando.
\end{tabular} & Requerido por tipo de operación & Numérico & 11,8 & F & FE, CCFE, NRE, NCE, NDE y CLE \\
\hline 89 & 7 & cuerpo Documento.ventaExenta & A & Ventas Exentas & \begin{tabular}{l}
Deberá detallar el valor de las ventas exentas de la operación, las cuales están dadas por el resultado de: [(precio unitario * cantidad) - "descuento, bonificación, rebajas por item"] \\
Si no existen ventas exentas deberá ingresar \$0.00
Se dará holgura de \$ 0.01 ctvs. Hacia arriba y hacia abajo por diferencias entre los cálculos en el sistema del contribuyente y la aplicación de fórmula para validación del cálculo de la A.T. \\
Nota: \\
Para el CLE, será el resultado de restar al "Total de operaciones Ventas exentas" - el "Monto global de Descuento, Bonificación, Rebajas y otros a Ventas gravadas" contenidos en el documento que se está liquidando.
\end{tabular} & Requerido por tipo de operación & Numérico & 11,8 & F & FE, CCFE, NRE, NCE, NDE y CLE \\
\hline 90 & 7 & cuerpoDocumento.ventaGravada & A & Ventas Gravadas & \begin{tabular}{l}  \\ \\ Deberá detallar el valor de las ventas gravadas de la operación, las cuales están dadas por el resultado de: [(precio unitario * cantidad) - "descuento, bonificación, rebajas por ítem"]Si no existen ventas gravadas deberá ingresar $0.00. \\ \\ Permite un máximo de 11 posiciones en el valor entero. Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero. \\ \\ Se dará holgura de $ 0.01 ctvs. Hacia arriba y hacia abajo por diferencias entre los cálculos en el sistema del contribuyente y la aplicación de fórmula para validación del cálculo de la A.T.
\\ \\ Nota: Para el CLE, será el resultado de restar al "Total de operaciones Ventas gravadas" y el "Monto global de Descuento, Bonificación, Rebajas y otros a Ventas gravadas" contenidos en el documento que se está liquidando.  \end{tabular} & \begin{tabular}{l} (Requerido por tipo de operación) \\ FEXE= \\ Requerido para su transmisión \end{tabular} & Numérico & 11,8 & F & FE, CCFE, NRE, NCE, NDE, CLE y FEXE \\
\hline 91 & 7 & cuerpoDocumento.exportaciones & A & Exportaciones & \begin{tabular}{l} Deberá detallar únicamente los valores de la factura de liquidación. Si no existen exportaciones deberá colocar $0.00. \\ \\ Se dará holgura de $ 0.01 ctvs. Hacia arriba y hacia abajo por diferencias entre los cálculos en el sistema del contribuyente y la aplicación de fórmula para validación del cálculo de la A.T. \\ \\ Nota: Cuando se informen documentos con estado invalidado/anulado, deberá ingresar los valores monetarios con signo negativo. \end{tabular} & Requerido por tipo de operación & Numérico & 11,8 & F & CLE \\
\hline 92 & 7 & cuerpoDocumento.valor & A & Valor Donado & \begin{tabular}{l} Deberá detallar el valor donado por cada ítem, el cual estará dado por el resultado de: [(valor unitario * cantidad) - depreciación]. \\ \\ Permite un máximo de 11 posiciones en el valor entero. Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero. \\ \\ Se dará holgura de $ 0.01 ctvs. Hacia arriba y hacia abajo por diferencias entre los cálculos en el sistema del contribuyente y la aplicación de fórmula para validación del cálculo de la A.T. \end{tabular} & Requerido para su transmisión & Numérico & 11,8 & TC & CDE \\
\hline 93 & 7 & cuerpoDocumento.Compra & A & Ventas & \begin{tabular}{l} Deberá indicar en este campo el monto de la venta, la cual estará dada por el resultado de: [(precio unitario * cantidad) - "Descuento, bonificación, rebajas por ítem"]. \\ \\ Permite un máximo de 11 posiciones en el valor entero. Podrá expresarse desde 1 hasta un máximo de 8 decimales después del valor entero. \end{tabular} & Requerido para su transmisión & Numérico & 11,8 & TC & FSEE \\
\hline 94 & 7 & cuerpoDocumento.tributos & C & Código del Tributo & \begin{tabular}{l} Deberá indicar el código de los tributos que apliquen al producto o servicio detallado por ítem (Ver catálogo: CAT-015 "Tributos" Secciones 1 y 3). \\ \\ Cuando en el documento existan ventas gravadas el campo debe contener por lo menos el código de tributo 20-IVA, se exceptúa de esta condición la FE ya que esta deberá presentar los valores con IVA incluido. \\ \\ Si en FE las ventas gravadas solo aplicaran a IVA deberá ingresar este campo con null. \\ \\ Cuando aplique más de un código de tributo este deberá ingresarse entre corchetes y separarse por comas. \\ \\ Este campo se completará con null, en los siguientes casos: \\ 1- Cuando en el ítem se detallen Ventas no sujetas. \\ 2- Cuando en el ítem se detallen Ventas exentas. \\ 3- Cuando se haga uso del campo "Cargos / Abonos que no afectan la base imponible". \\ \\ Para los casos de CCFE, NRE, NCE, NDE cuando se haga uso de campo "Tributo sujeto a cálculo de IVA" podrá ingresar en el ítem únicamente el código 20-IVA. \\ \\ Para el caso de FE cuando se haga uso de campo "Tributo sujeto a cálculo de IVA" deberá ingresar este ítem la palabra null. \\ \\ Para el caso especial del CLE solo aplicarán los tributos contenidos en la sección 1 del catálogo CAT-015 "tributos". \\ \\ Nota: Los tributos contenidos en este campo se reflejarán en la sección "resumen" de la siguiente manera: \\ \\ En el campo "resumen código de tributo" se ingresará de manera consolidada (una sola vez) cada tipo de tributo por medio del código que haya aplicado por ítem. \end{tabular} & Requerido por tipo de operación & Alfanumérico & Longitud: 2 & TC & FE, CCFE, NRE, NCE, NDE, CLE, y FEXE \\
\end{tabular}