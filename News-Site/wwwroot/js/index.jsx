import Header from './Components/Header'
class App extends React.Component {
    render() {
        return (
            <div >
                <Header />
            </div>
        );
    }
}

ReactDOM.render(<CommentBox />, document.getElementById('content'));