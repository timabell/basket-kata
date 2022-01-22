import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src="logo.svg" className="App-logo" alt="logo" />
        <h1>
			<a href="https://github.com/timabell/basket-kata" target="_blank">Basket Kata</a>, now with added ReactJs
        </h1>
      </header>
	<body>
		<div id="basket">
			<h2>Add items</h2>
			<div>
				<label>Name: <input placeholder="e.g. Milk"></input></label>
				<br/>
				<label>Price: <input placeholder="£0.00"></input></label>
				<br/>
				<button>Add</button>
			</div>
			<h2>Basket</h2>
			<ol>
				<li>basket things here</li>
				<li>...</li>
			</ol>
			<h2>Empty basket</h2>
			<div>
				<button>Clear</button>
			</div>
		</div>
	</body>
    </div>
  );
}

export default App;
