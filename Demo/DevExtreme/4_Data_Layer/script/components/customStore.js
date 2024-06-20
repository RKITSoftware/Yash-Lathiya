export default function showCustomStore() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div id='heading'></div>
    <div class='row'>
      <div id='byKey'></div>
    </div>
    <div class='row'>
      <div id='clearRowDataCache'></div>
    </div>
    <div class='row'>
      <div id='createQuery'></div>
    </div>
    <div class='row'>
      <div id='insert'></div>
    </div>
    <div class='row'>
      <div id='key'></div>
    </div>
    <div class='row'>
      <div id='keyOf'></div>
    </div>
    <div class='row'>
      <div id='load'></div>
    </div>
    <div class='row'>
      <div id='push'></div>
    </div>
    <div class='row'>
      <div id='remove'></div>
    </div>
    <div class='row'>
      <div id='totalCount'></div>
    </div>
    <div class='row'>
      <div id='update'></div>
    </div>`
  );

  $("#heading").dxButton({
    text: "Custom Store",
    onClick: () => {
      console.log(store);
    },
  });

  var store = new DevExpress.data.CustomStore({
    key: "id",

    loadMode: "row", // accepted value -> row & processed

    // cacheRowData: true,

    loadMode: "processed", // default value => processed , accepted value => processed, row

    useDefaultSearch: true,

    byKey: (key) => {
      var d = $.Deferred();
      $.get("https://jsonplaceholder.typicode.com/todos/" + key).done(
        (dataItem) => {
          d.resolve(dataItem);
        }
      );
      return d.promise();
    },

    load: function (loadOptions) {
      return $.ajax({
        url: "https://jsonplaceholder.typicode.com/todos",
        method: "GET",
      });
    },

    insert: function (values) {
      return $.ajax({
        url: "https://jsonplaceholder.typicode.com/todos",
        method: "POST",
        data: values,
      });
    },

    update: function (key, values) {
      return $.ajax({
        url: "https://jsonplaceholder.typicode.com/todos/" + key,
        method: "PUT",
        data: values,
      });
    },

    remove: function (key) {
      return $.ajax({
        url: "https://jsonplaceholder.typicode.com/todos/" + key,
        method: "DELETE",
      });
    },

    onInserting: (values) => {
      console.log("*inserting..", "values", values);
    },

    onInserted: (values, key) => {
      console.log("*inserted..", "key", key, "values", values);
    },

    onLoaded: (result) => {
      console.log("*loaded..", "result", result);
    },

    onLoading: (loadOptions) => {
      console.log("*loading..", "loadOptions", loadOptions);
    },

    onModified: () => {
      console.log("*modified..");
    },

    onModifying: () => {
      console.log("*modifying..");
    },

    onPush: (inputArr) => {
      console.log("*push", "inputArr", inputArr);

      if (inputArr[0].type == "insert") {
        console.log("fetched insert");
        const dataToAdded = inputArr[0].data;
        store.insert(dataToAdded);
      } else if (inputArr[0].type == "update") {
        console.log("fetched update");
        const keyToUpdate = inputArr[0].key;
        const updatedData = inputArr[0].data;
        store.update(keyToUpdate, updatedData);
      } else if (inputArr[0].type == "remove") {
        console.log("fetched remove");
        const keyToRemove = inputArr[0].key;
        store.remove(keyToRemove);
      }
    },

    onRemoving: (key) => {
      console.log("*removing..", "key", key);
    },

    onRemoved: (key) => {
      console.log("*removed..", "key", key);
    },

    onUpdated: (key, values) => {
      console.log("*updated..", "key", key, "values", values);
    },

    onUpdating: (key, values) => {
      console.log("*updating..", "key", key, "values", values);
    },

    totalCount: () => {
      return 200;
    },

    errorHandler: (err) => {
      console.log("err", err);
    },
  });

  $("#byKey").dxButton({
    text: "By Key (1)",
    onClick: () => {
      store
        .byKey(1)
        .done((dataItem) => {
          console.log("done", "dataItem", dataItem);
        })
        .fail((err) => {
          console.log("fail", err);
        });
    },
  });

  $("#clearRowDataCache").dxButton({
    text: "Clear Row Data Cache",
    onClick: () => {
      store.clearRawDataCache();
      console.log("cleared cache");
    },
  });

  $("#insert").dxButton({
    text: "Insert 4 Gujarat Gandhinagar into store",
    onClick: () => {
      store
        .insert({
          id: 4,
          state: "Gujarat",
          capital: "Gandhinagar",
        })
        .done((dataObj, key) => {
          console.log(
            "**done | data inserted ",
            "dataObj",
            dataObj,
            "key",
            key
          );
        })
        .fail(() => {
          console.log("**fail | data insertion failed");
        });
    },
  });

  $("#key").dxButton({
    text: "Key",
    onClick: () => {
      var keyProps = store.key();
      console.log("keyProps", keyProps);
    },
  });

  $("#keyOf").dxButton({
    text: "keyOf id 2",
    onClick: () => {
      var key = store.keyOf({
        id: 2,
        state: "Alaska",
        capital: "Juneau",
      });
      console.log("key", key);
    },
  });

  $("#load").dxButton({
    text: "load",
    onClick: () => {
      store.load();
    },
  });

  $("#push").dxButton({
    text: "Push",
    onClick: () => {
      console.log("******** push = insert ********");
      store.push([
        {
          type: "insert",
          data: { id: 4, state: "Gujarat", capital: "Gandhinagar" },
          index: 4,
        },
      ]);
      console.log("******** push = update ********");
      store.push([
        {
          type: "update",
          data: { id: 4, state: "Gujarat", capital: "Surat" },
          key: 4,
        },
      ]);
      console.log("******** push = remove ********");
      store.push([
        {
          type: "remove",
          key: 4,
        },
      ]);
    },
  });

  $("#remove").dxButton({
    text: "Remove",
    onClick: () => {
      store.remove(3); // parameter => key
    },
  });

  $("#totalCount").dxButton({
    text: "Total",
    onClick: () => {
      store.totalCount().done((count) => console.log(count));
    },
  });

  $("#update").dxButton({
    text: "Upadte 1 Delhi New Delhi",
    onClick: () => {
      store
        .update(1, {
          state: "Delhi",
          capital: "New Delhi",
        })
        .done(() => {});
    },
  });
}
