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
        return { __html: rawMarkup };
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
        const newsNodes = this.props.data.map(news => (
            <News name={news.name}>
                {news.text}
            </News>
        ));
        return <div className="newsList">{newsNodes}</div>;
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