import React, { useEffect, useState} from "react";
import axios from "axios";

const GameList = () => {
    const [games, setGames] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get("/api/games")
        .then((response) => setGames(response.data))
        .catch((error) => {
            console.error("Error while fetching games:", error);
            setError("Failed to load games list");
        })
    }, [])

    if (error) return <p>{error}</p>

    return (
        <div>
            <h2> 3DS Games</h2>
            <ul>
                {games.map((game) => (
                    <li key = {game.gameId}>
                        <strong>{game.title}</strong> - {game.publisher} ({game.releaseDate})
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default GameList