export default class Plant{
    id = 0;
    name = '';
    type = '';
    height = 0;
    imageBase64 = '';

    constructor(id, name, type, height, imageBase64) {
        this.id = id;
        this.name = name;
        this.type = type;
        this.height = height;
        this.imageBase64 = imageBase64;
    }
}