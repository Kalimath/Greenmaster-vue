export const SUPPORTED_FILETYPES = ["JSON","SVG"]

/**
 * Downloads given object as json with fileName
 * @param exportObj
 * @param {string} fileName
 * */
export function downloadObjectAsJson(exportObj, fileName){
    let dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(exportObj));
    downloadData(fileName,".json", dataStr)
}

/**
 * Downloads given object as svg with fileName
 * @param svgData
 * @param {string} fileName
 * */
export function downloadObjectAsSvg(svgData, fileName){
    let svgBlob = new Blob([svgData], {type:"image/svg+xml;charset=utf-8"});
    let svgUrl = URL.createObjectURL(svgBlob);
    let downloadLink = document.createElement("a");
    downloadLink.href = svgUrl;
    downloadLink.download = fileName+".svg";
    document.body.appendChild(downloadLink);
    downloadLink.click();
    document.body.removeChild(downloadLink);
}

/**
 * Removes non-useful items from given garden
 * @param garden
 * */
export function makeGardenReadyForExport(garden) {
    let readyForExport = {...garden}
    if(isValidGarden(readyForExport)){
        delete readyForExport['background']
        return readyForExport
    }else {
        throw new TypeError("given garden is not valid")
    }
}

export function isValidGarden(gardenToEvaluate){
    return gardenToEvaluate.name && gardenToEvaluate.zones
}

/**
 * Downloads given data as fileType with fileName
 * @param {string} fileName
 * @param {string} fileType
 * @param data
 * */
export function downloadData(fileName,fileType, data) {
    if(fileName && isValidJsonOrSvgType(fileType) && data) {
        let downloadAnchorNode = document.createElement('a');
        downloadAnchorNode.setAttribute("href", data);
        downloadAnchorNode.setAttribute("download", fileName + fileType);
        document.body.appendChild(downloadAnchorNode); // required for firefox
        downloadAnchorNode.click();
        downloadAnchorNode.remove();
    }else{
        throw new TypeError("Could not start downloading data: fileName/fileType/data is empty or invalid")
    }
}
/**
 * Checks if given type is correct for an svg or json
 * @param {string} fileName
 * @param {string} fileType
 * @param data
 * */
export function isValidJsonOrSvgType(type){
    return type &&  (type ===".json"||type ===".svg")
}