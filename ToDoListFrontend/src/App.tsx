import InputField from "./components/InputField/InputField";
import "bootstrap/dist/css/bootstrap.min.css";
import ToDoList from "./components/ToDoList/ToDoList";

const App = () => {
  return (
    <>
      <ToDoList />
      <InputField />
    </>
  );
};

export default App;
