(defblock :name subscribe-handler :is-top t
	(worker
		:worker-name subscribe-handler
		:verb "handler"
		:description "Subscribes a handler to the subscriber."
		:usage-samples (
			"sub handler Foo.Handlers.MyHandler"
			"sub handler Foo.Handlers.AnotherHandler -t 'some-topic'"
			"sub handler Foo.Handlers.AnotherHandler --topic 'some-topic'"))

	(end)
)
