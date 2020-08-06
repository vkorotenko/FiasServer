/**
 * Интерфейс файлов обновлений
 */
export interface FilesInfo {
  /**
   * fiasCompleteDbfUrl: "https://fias.nalog.ru/DownloadUpdates?file=fias_dbf.zip&version=20200804"
fiasCompleteXmlUrl: "https://fias.nalog.ru/DownloadUpdates?file=fias_xml.zip&version=20200804"
fiasDeltaDbfUrl: "https://fias.nalog.ru/DownloadUpdates?file=fias_delta_dbf.zip&version=20200804"
fiasDeltaXmlUrl: "https://fias.nalog.ru/DownloadUpdates?file=fias_delta_xml.zip&version=20200804"
kladr4ArjUrl: "https://fias.nalog.ru/DownloadUpdates?file=base.arj&version=20200804"
kladr47ZUrl: "https://fias.nalog.ru/DownloadUpdates?file=base.7z&version=20200804"
textVersion: "БД ФИАС от 04.08.2020"
versionId: 20200804
   */

  versionId: String
  textVersion: String
  kladr47ZUrl: String
  kladr4ArjUrl: String
  fiasDeltaXmlUrl: String
  fiasDeltaDbfUrl: String
  fiasCompleteXmlUrl: String
  fiasCompleteDbfUrl: String
}
