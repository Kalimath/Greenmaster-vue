class Artist {
    
    /**
     * Adds the given image with url instance to the group with given size and id.
     *
     * @param{group} group
     * @param{string}imageUrl
     * @param{number} width
     * @param{number} height
     * @Param {string} id - default is empty
     * */
    static DrawImage(group, imageUrl, width, height, id) {
        return group.image(imageUrl).move(0, 0).attr({width:width, height:height, id: id})
    }

    /**
     * Adds a point instance to the group with given coordinate(vertex), size, color and id.
     *
     * @param{group} group
     * @param{Vertex}vertex
     * @param{number} size
     * @param{string} color - default is red
     * @Param {string} id - default is empty
     * */
    static DrawPoint(group, vertex, size, color = "red", id = "") {
        return group.circle(size).move(vertex.x, vertex.y).attr({fill: color, id: id}).click(function () {
            this.fill({ color: color})
            this.SelectedVertex = this;
        });
    }

    /**
    * Adds a line instance to the group with given from vertex1 to vertex2 with given size and color.
    *
    * @param{group} group
    * @param{Vertex}vertex1
    * @param{Vertex} vertex2
    * @param{number} size
    * @param{string} color - default is red
    * */
    static DrawLine(group, vertex1, vertex2, size, color = "red") {
        return group.line(vertex1.x, vertex1.y, vertex2.x, vertex2.y).stroke({color: color, width: size, linecap: 'round'})
    }
}

export default Artist;