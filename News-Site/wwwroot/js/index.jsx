
function createRemarkable() {
    var remarkable =
        'undefined' != typeof global && global.Remarkable
            ? global.Remarkable
            : window.Remarkable;

    return new remarkable();
}

class News extends React.Component {
    rawMarkup() {
        var md = createRemarkable();
        var rawMarkup = md.render(this.props.children.toString());
        return {__html: rawMarkup};
    }

    render() {
        return (
            <div >
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
            </div>
        );
    }
}
class NewsList extends React.Component {
    render() {
        const newsHeader = this.props.data.map(news => (
            <News name={news.newsName}>
                {news.newsHeader}
            </News>
        ));
        const newsSubtitle = this.props.data.map(news => (
            <News name={news.newsName}>
                {news.newsSubtitle}
            </News>
        ));
        const newsText = this.props.data.map(news => (
            <News name={news.newsName}>
                {news.newsText}
            </News>
        ));
        const newsImage = this.props.data.map(newsI => (
            <img src={newsI.newsImagePath} />
            ));
        
        return (
            
                <Card style={{ width: '18rem' }} className="newsList">
                <Card.Img variant="top" src={newsImage} />
                    <Card.Body>
                    <Card.Title>{newsHeader}</Card.Title>
                    <Card.Text>
                        {newsText}
                        </Card.Text>
                        <Button variant="primary">Go somewhere</Button>
                    </Card.Body>
                </Card>
            );
    }
}
class NewsBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: this.props.initialData };
    }
    loadCommentsFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
    componentDidMount() {
        window.setInterval(
            () => this.loadCommentsFromServer(),
            this.props.pollInterval
        );
    }
    render() {
        return (
            <div className="newsBox">
                <h1>News</h1>
                <NewsList data={this.state.data} />
            </div>
        );
    }
}